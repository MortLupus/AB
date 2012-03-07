using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MVC4.Installers
{
    public class ModelBinderInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<DefaultModelBinder>().LifestyleTransient());
            container.Register(Classes.FromThisAssembly().BasedOn<IModelBinder>().LifestyleTransient());
        }
    }
}