using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Hilvilla.Dominio.Model;

namespace Hilvilla.Dominio.Repositorios
{
    public class MarcaRepositorio : IRepositorio<Marca>
    {
        #region IRepositorio<Marca> Members

        public int Save(Marca entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                    return entity.IdMarca;
                }
            }
            
        }

        public void Update(Marca entity)
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

        public void Delete(Marca entity)
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

        public Marca GetById(Int32 id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Marca>().Add(Restrictions.Eq("IdMarca", id)).UniqueResult<Marca>();
        }

        public IList<Marca> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Marca));

                return criteria.List<Marca>();
            }
        }

        #endregion
    }
}
