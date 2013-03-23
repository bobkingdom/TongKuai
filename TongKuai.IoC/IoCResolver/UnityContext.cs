using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TongKuai.IoC.IoCResolver
{
    public sealed class UnityContext
    {
        private IUnityContainerStorage _storage;
        private static UnityContext _current;

        private UnityContext()
        {
            _storage = new WebUnityContainerStorage();
        }

        /// <summary>
        /// 单例方式实例化
        /// </summary>
        public static UnityContext Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new UnityContext();
                }
                return _current;
            }
        }

        /// <summary>
        /// Unity的IoC容器对象 (存放在HttpContext.Current.Application中)
        /// </summary>
        public IUnityContainer Container
        {
            get
            {
                IUnityContainer container = _storage.Get();
                if (container == null)
                {
                    container = new UnityContainerBuilder().BuilderUnityContainer();
                    _storage.Set(container);
                }

                return container;
            }
        }

        public void SetStorage(IUnityContainerStorage storage)
        {
            _storage = storage;
        }

        public void SetStorage<TStorage>() where TStorage : IUnityContainerStorage, new()
        {
            _storage = new TStorage();
        }
    }
}
