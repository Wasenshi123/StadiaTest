using System.Web.Http;
using Owin;

namespace WebService
{
    public class Startup
    {
        public static void ConfigureApp(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            // Default Route pattern for this Service
            config.Routes.MapHttpRoute(
                name: "Default Api",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            

            appBuilder.UseWebApi(config);
        }
    }
}
