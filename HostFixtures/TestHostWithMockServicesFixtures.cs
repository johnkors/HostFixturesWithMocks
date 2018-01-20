using System.Threading.Tasks;
using Host;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HostFixtures
{
    public class UnitTest1
    {
        [Fact]
        public async Task TestMockingOfRegistrationsInStartup()
        {
            var webHost = new WebHostBuilder()
                .UseStartup<Host.Startup>()
                .ConfigureTestServices(s => s.AddSingleton<IFoo, MockedFoo>());

            var testserver = new TestServer(webHost);
            var client = testserver.CreateClient();

            var response = await client.GetStringAsync("/");
            Assert.Equal("HostFixtures.MockedFoo", response);
        }
    }

    public class MockedFoo : IFoo
    {
    }
}
