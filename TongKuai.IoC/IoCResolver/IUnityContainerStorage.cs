using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TongKuai.IoC.IoCResolver
{
    public interface IUnityContainerStorage
    {
        IUnityContainer Get();
        void Set(IUnityContainer container);
    }
}
