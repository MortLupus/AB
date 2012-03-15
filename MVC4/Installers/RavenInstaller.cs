using System.Web;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Infrastructure;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace MVC4.Installers
{
    public class RavenInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDocumentStore>().Instance(CreateDocumentStore()).LifeStyle.Singleton,
                Component.For<IDocumentSession>().UsingFactoryMethod(GetDocumentSession).OnDestroy(Test).LifeStyle.PerWebRequest);
        }

        private void Test(IDocumentSession session)
        {
            if (session == null)
                return;
            if (HttpContext.Current.Server.GetLastError() != null)
                 return;

            session.SaveChanges();
        }

        private static IDocumentStore CreateDocumentStore()
        {
            var store = new DocumentStore
                            {
                                ConnectionStringName = "RavenDB"
                            };
            //var store = new EmbeddableDocumentStore
            //                {
            //                    DataDirectory = "Data"
            //                };
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
