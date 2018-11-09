using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Redirector
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration config) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            var url = config["redirectUrl"] ?? "https://vanced.app";
            app.Run(async (context) =>
            {
                context.Response.Redirect(url, permanent: true);
                await context.Response.WriteAsync($"New official url: {url}");
            });
        }
    }
}
