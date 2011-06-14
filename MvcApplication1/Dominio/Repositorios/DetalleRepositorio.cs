using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Hilvilla.Dominio.Model;

namespace Hilvilla.Dominio.Repositorios
{
    public class DetalleRepositorio : IRepositorio<Detalle>
    {
        #region IRepositorio<Detalle> Members

        int IRepositorio<Detalle>.Save(Detalle entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                    return entity.IdDetalle;
                }
            }
            
        }

        void IRepositorio<Detalle>.Update(Detalle entity)
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

        void IRepositorio<Detalle>.Delete(Detalle entity)
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

        Detalle IRepositorio<Detalle>.GetById(Int32 id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Detalle>().Add(Restrictions.Eq("IdDetalle", id)).UniqueResult<Detalle>();
        }

        IList<Detalle> IRepositorio<Detalle>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Detalle));

                return criteria.List<Detalle>();
            }
        }

        #endregion
    }
}
