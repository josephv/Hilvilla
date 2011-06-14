using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Hilvilla.Dominio.Model;

namespace Hilvilla.Dominio.Repositorios
{
    public class MotorRepositorio : IRepositorio<Motor>
    {
        #region IRepositorio<Motor> Members

        int IRepositorio<Motor>.Save(Motor entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                    return entity.IdMotor;
                }
            }
            
        }

        void IRepositorio<Motor>.Update(Motor entity)
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

        void IRepositorio<Motor>.Delete(Motor entity)
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

        Motor IRepositorio<Motor>.GetById(Int32 id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Motor>().Add(Restrictions.Eq("IdMotor", id)).UniqueResult<Motor>();
        }

        IList<Motor> IRepositorio<Motor>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Motor));

                return criteria.List<Motor>();
            }
        }

        #endregion
    }
}
