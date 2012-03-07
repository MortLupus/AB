using System;
using System.Web;
using NHibernate;
using NHibernate.Context;

namespace Infrastructure.NHibernate
{
    public class NHUnitOfWorkModule : IHttpModule
    {
        #region IHttpModule Members

        public void Init(HttpApplication context)
        {
            context.BeginRequest += InitializeSession;
            context.EndRequest += CloseSession;
        }

        public void Dispose()
        {
        }

        #endregion

        private void InitializeSession(object sender, EventArgs eventArgs)
        {
            var sessionFactory = IoC.Instance.Resolve<ISessionFactory>();

            ISession session = sessionFactory.OpenSession();
            session.BeginTransaction();
            CurrentSessionContext.Bind(session);
        }

        private void CloseSession(object sender, EventArgs eventArgs)
        {
            var sessionFactory = IoC.Instance.Resolve<ISessionFactory>();
            ISession session = CurrentSessionContext.Unbind(sessionFactory);

            ITransaction transaction = session.Transaction;

            if (transaction != null && transaction.IsActive)
                session.Transaction.Commit();

            session.Close();
        }
    }
}