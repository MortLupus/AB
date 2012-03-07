using System.Web.Mvc;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Raven.Client;
using Raven.Client.Document;

namespace MVC4.Installers
{
    public class RavenInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDocumentStore>().Instance(CreateDocumentStore()).LifeStyle.Singleton,
                Component.For<IDocumentSession>().UsingFactoryMethod(GetDocumentSession).LifeStyle.PerWebRequest);
        }

        private static IDocumentStore CreateDocumentStore()
        {
            var store = new DocumentStore
                            {
                                ConnectionStringName = "RavenDB"
                            };
            store.Initialize();
            return store;
        }

        private static IDocumentSession GetDocumentSession(IKernel kernel)
        {
            var store = kernel.Resolve<IDocumentStore>();
            return store.OpenSession();
        }
    }
}
