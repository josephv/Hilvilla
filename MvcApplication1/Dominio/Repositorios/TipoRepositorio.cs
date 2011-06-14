using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Hilvilla.Dominio.Model;

namespace Hilvilla.Dominio.Repositorios
{
    public class TipoRepositorio : IRepositorio<Tipo>
    {
        #region IRepositorio<Tipo> Members

        int IRepositorio<Tipo>.Save(Tipo entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                    return entity.IdTipo;
                }
            }
            
        }

        void IRepositorio<Tipo>.Update(Tipo entity)
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

        void IRepositorio<Tipo>.Delete(Tipo entity)
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

        Tipo IRepositorio<Tipo>.GetById(Int32 id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Tipo>().Add(Restrictions.Eq("IdTipo", id)).UniqueResult<Tipo>();
        }

        IList<Tipo> IRepositorio<Tipo>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Tipo));

                return criteria.List<Tipo>();
            }
        }

        #endregion
    }
}
