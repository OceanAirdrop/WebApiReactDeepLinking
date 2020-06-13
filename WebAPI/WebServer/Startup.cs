using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPIReactDeepLinking.WebHandlers;

namespace WebAPIReactDeepLinking.WebServer
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Step 01: Configure Web API for self-host. 

            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Step 02: Enable Swagger!
            config.EnableSwagger(c => c.SingleApiVersion("v1", "CRT Scada Client API")).EnableSwaggerUi();

            // Step 03: Add Default Web Handlers
            // Always log every call to the we service ( so I can see what is happening ) 
            config.MessageHandlers.Add(new LogHTTPRequestResponse());  

            // Step 04: Enable Cors
            config.EnableCors();
            appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);  //Install-Package Microsoft.Owin.Cors

            // This will use index.html as the default file
            appBuilder.UseDefaultFiles();
            appBuilder.UseStaticFiles("/www");

            // Step 05: ServeUnknownFileTypes  for SPA React App
            ConfigureSpaFileBrowsing(appBuilder);

            appBuilder.UseWebApi(config);
        }


        public void ConfigureSpaFileBrowsing(IAppBuilder appBuilder)
        {
            // needed for React
            var options = new FileServerOptions();
            options.EnableDirectoryBrowsing = true;
            options.FileSystem = new PhysicalFileSystem("./www");
            options.StaticFileOptions.ServeUnknownFileTypes = true;
            appBuilder.UseFileServer(options);
        }
    }
}
