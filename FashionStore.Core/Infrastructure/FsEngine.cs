using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Autofac;

namespace FashionStore.Core.Infrastructure
{
    public class FsEngine : IEngine
    {
        private ContainerManager _containerManager;

        public FsEngine() : this(new ContainerConfigurer())
        {
        }

        public FsEngine(ContainerConfigurer configurer)
        {
            InitializeContainer(configurer);
        }

        private void InitializeContainer(ContainerConfigurer configurer)
        {
            var builder = new ContainerBuilder();
            _containerManager = new ContainerManager(builder.Build());
            configurer.Configure(this, _containerManager);
        }

        public ContainerManager ContainerManager
        {
            get
            {
                return _containerManager;
            }
        }

        public T Resolve<T>() where T : class
        {
            return ContainerManager.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return ContainerManager.Resolve(type);
        }

        public T[] ResolveAll<T>()
        {
            return ContainerManager.ResolveAll<T>();
        }
    }
}
