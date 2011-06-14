using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Hilvilla.Dominio.Model;

namespace Hilvilla.Dominio.Repositorios
{
    public class CotizacionRepositorio : IRepositorio<Cotizacion>
    {
        #region IRepositorio<Cotizacion> Members

        int IRepositorio<Cotizacion>.Save(Cotizacion entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                    return entity.IdCotizacion;
                }
            }
            
        }

        void IRepositorio<Cotizacion>.Update(Cotizacion entity)
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

        void IRepositorio<Cotizacion>.Delete(Cotizacion entity)
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

        Cotizacion IRepositorio<Cotizacion>.GetById(Int32 id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Cotizacion>().Add(Restrictions.Eq("IdCotizacion", id)).UniqueResult<Cotizacion>();
        }

        IList<Cotizacion> IRepositorio<Cotizacion>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Cotizacion));

                return criteria.List<Cotizacion>();
            }
        }

        #endregion
    }
}
