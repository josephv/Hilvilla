using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Hilvilla.Dominio.Model;

namespace Hilvilla.Dominio.Repositorios
{
    public class ClienteRepositorio : IRepositorio<Cliente>
    {
        #region IRepositorio<Cliente> Members

        int IRepositorio<Cliente>.Save(Cliente entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                    return 1;
                }
            }
            
        }

        void IRepositorio<Cliente>.Update(Cliente entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(entity);
                    transaction.Commit();
                }
            }
        }

        void IRepositorio<Cliente>.Delete(Cliente entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        Cliente IRepositorio<Cliente>.GetById(Int32 id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Cliente>().Add(Restrictions.Eq("RifCedula", id)).UniqueResult<Cliente>();
        }

        IList<Cliente> IRepositorio<Cliente>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Cliente));

                return criteria.List<Cliente>();
            }
        }

        #endregion
    }
}
