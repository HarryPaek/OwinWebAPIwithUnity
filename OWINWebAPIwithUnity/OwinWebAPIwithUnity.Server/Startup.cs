using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Web.Http;
using Unity;

namespace OwinWebAPIwithUnity.Server
{
    public class Startup
    {
        private static readonly IUnityContainer _container = UnityHelpers.GetConfiguredContainer();

        public Startup()
        {
        }

        public static void StartServer()
        {
            string baseAddress = "http://192.168.0.28:28080/";
            var startup = _container.Resolve<Startup>();
            IDisposable webApplication = WebApp.Start(baseAddress, startup.Configuration);

            try
            {
                Console.WriteLine("Started...");

                Console.ReadKey();
            }
            finally
            {
                webApplication.Dispose();
            }
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new UnityDependencyResolver(UnityHelpers.GetConfiguredContainer());

            config.Routes.MapHttpRoute(
                          name: "DefaultApi",
                          routeTemplate: "api/{controller}/{id}",
                          defaults: new { id = RouteParameter.Optional }
                      );

            config.Services.Add()

            appBuilder.UseWebApi(config);
        }
    }
}
