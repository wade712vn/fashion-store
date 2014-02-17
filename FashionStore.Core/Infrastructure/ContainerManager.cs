using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace FashionStore.Core.Infrastructure
{
    public class ContainerManager
    {
        private IContainer _container;

        public ContainerManager(IContainer container)
        {
            _container = container;
        }

        public object Resolve(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }
    }
}
