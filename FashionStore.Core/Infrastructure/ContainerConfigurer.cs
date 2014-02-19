using System;
using System.Collections.Generic;
using System.Linq;
using FashionStore.Core.Infrastructure;

namespace FashionStore.Core.Infrastructure
{
    /// <summary>
    /// Configures the inversion of control container with services.
    /// </summary>
    public class ContainerConfigurer
    {
        public virtual void Configure(IEngine engine, ContainerManager containerManager)
        {
            //other dependencies
            containerManager.AddComponentInstance<IEngine>(engine, "fs.engine");
            containerManager.AddComponentInstance<ContainerConfigurer>(this, "fs.containerConfigurer");

            //type finder
            containerManager.AddComponent<ITypeFinder, WebAppTypeFinder>("nop.typeFinder");

            //register dependencies provided by other assemblies
            var typeFinder = containerManager.Resolve<ITypeFinder>();
            containerManager.UpdateContainer(x =>
            {
                var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
                
                var drInstances = drTypes.Select(drType => (IDependencyRegistrar) Activator.CreateInstance(drType)).ToList();
                //sort
                drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
                foreach (var dependencyRegistrar in drInstances)
                {
                    dependencyRegistrar.Register(x, typeFinder);
                }
            });

        }
    }
}
