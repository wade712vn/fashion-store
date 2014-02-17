using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

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
    }
}
