using AutoMapper;
using System.Web.Http;
using TankCrud.Mapping;

namespace TankCrud
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<EntitiesToDTOProfile>();
            });
        }
    }
}
