using Microsoft.Practices.Unity;
using System.Web;

namespace TongKuai.IoC.IoCResolver
{
    public class WebUnityContainerStorage : IUnityContainerStorage
    {
        public IUnityContainer Get()
        {
            return (IUnityContainer)HttpContext.Current.Application["container"];
        }

        public void Set(IUnityContainer container)
        {
            HttpContext.Current.Application["container"] = container;
        }
    }
}
