using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;

namespace CoreMvcCkFinder.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMvc().AddXmlSerializerFormatters();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("ElFinderForCkEditor", "/elfinder", new { controller = "ElFinder", action = "Index" });
                endpoints.MapControllerRoute("ElFinderFileManager", "/elfinder/file-manager", new { controller = "ElFinder", action = "FileManager" });
                endpoints.MapControllerRoute("ElFinderConnector", "/elfinder/connector", new { controller = "ElFinder", action = "Connector" });
                endpoints.MapControllerRoute("ElFinderThumbnail", "/elfinder/thumb/{hash}", new { controller = "ElFinder", action = "Thumbs" });
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Assets")),
                RequestPath = "/Assets"
            });
        }
    }
}
