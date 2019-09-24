using ParkingLotV1.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ParkingLotV1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ISpecialService, SpecialService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}