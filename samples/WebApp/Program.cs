using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Shirhatti.Graphviz;
using System.Threading;

namespace WebApp
{
    public class Program
    {
        // Graphviz is not threadsafe, so we're using a ThreadLocal to avoid locking
        private static readonly ThreadLocal<Graphviz> _graphviz = new(() => new Graphviz());
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Program>();
                });

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    string dot = "digraph D { A-> { B, C, D} -> { F} }";
                    using Cgraph cgraph = new Cgraph(dot);
                    byte[] image = _graphviz.Value.RenderDot(cgraph, OutputFormat.Svg);
                    context.Response.ContentType = "image/svg+xml";
                    await context.Response.Body.WriteAsync(image);
                });
            });
        }
    }
}
