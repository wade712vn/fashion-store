using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionStore.Core.Infrastructure;

namespace FashionStore.Web.Ioc
{
    public class FsDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}