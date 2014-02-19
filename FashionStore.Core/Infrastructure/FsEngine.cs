using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Autofac;
using FashionStore.Core.Domain.Catalog;

namespace FashionStore.Core.Infrastructure
{
    public class FsEngine
    {
        private ContainerManager _containerManager;

        public FsEngine()
        {
            InitializeContainer();
        }

        private void InitializeContainer()
        {
            var builder = new ContainerBuilder();
            
            _containerManager = new ContainerManager(builder.Build());
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
