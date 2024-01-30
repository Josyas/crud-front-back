using System.Web.Http;
using System.Web.Http.Cors;
using TankCrud_Domain.Services;
using TankCrud_Infrastructure.Database;
using TankCrud_Infrastructure.Repositories;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace TankCrud
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            #region DbContext
              container.RegisterType<AppDbContext>(new HierarchicalLifetimeManager());
            #endregion

            #region Services
              container.RegisterType<ITankService, TankService>(); 
              container.RegisterType<IProductTypeService, ProductTypeService>();
            #endregion

            #region Repositories
              container.RegisterType<IProductTypeRepository, ProductTypeRepository>();
              container.RegisterType<ITankRepository, TankRepository>();
            #endregion

           // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);
        }
    }
}
