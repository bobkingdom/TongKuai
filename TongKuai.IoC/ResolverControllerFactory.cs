using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TongKuai.IoC
{
    /// <summary>
    /// 自定义的控制器实例化工厂
    /// </summary>
    public class ResolverControllerFactory
    {

        public IControllerFactory GetControllerFactory()
        {

            return IoCHelper.Resolve<IControllerFactory>();

        }
    }
}
