using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Hilvilla.Dominio.Model;

namespace Hilvilla.Dominio.Repositorios
{
    public class CotizacionDetalleRepositorio : IRepositorio<CotizacionDetalle>
    {
        #region IRepositorio<CotizacionDetalle> Members

        int IRepositorio<CotizacionDetalle>.Save(CotizacionDetalle entity)
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

        void IRepositorio<CotizacionDetalle>.Update(CotizacionDetalle entity)
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

        void IRepositorio<CotizacionDetalle>.Delete(CotizacionDetalle entity)
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

        CotizacionDetalle IRepositorio<CotizacionDetalle>.GetById(Int32 id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<CotizacionDetalle>().Add(Restrictions.Eq("IdCotizacion", id)).UniqueResult<CotizacionDetalle>();
        }

        IList<CotizacionDetalle> IRepositorio<CotizacionDetalle>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(CotizacionDetalle));

                return criteria.List<CotizacionDetalle>();
            }
        }

        #endregion
    }
}
