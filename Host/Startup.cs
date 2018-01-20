using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFoo, ActualFoo>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async (context) =>
            {
                var service = app.ApplicationServices.GetService(typeof(IFoo));
                await context.Response.WriteAsync(service.GetType().ToString());
            });
        }
    }

    public interface IFoo { }
    public class ActualFoo : IFoo { }
}
