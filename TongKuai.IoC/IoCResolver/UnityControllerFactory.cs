using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace TongKuai.IoC.IoCResolver
{
    /// <summary>
    /// 自定义的控制器，使MVC控制器可以支持依赖注入
    /// </summary>
    public class UnityControllerFactory : DefaultControllerFactory
    {
        private IUnityContainer _container;

        public UnityControllerFactory()
        {
            _container = UnityContext.Current.Container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException("requestContext");
            }
            if (controllerType == null)
            {
                throw new ArgumentNullException("controllerType");
            }

            IController controller = _container.Resolve(controllerType) as IController;

            return controller;
        }
    }
}
