
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Infra.Data.Contexto;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ECOM.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> :  IRepositoryBase<TEntity> where TEntity : class
    {
        protected EcomContext Context { get; private set; }
        private DbSet<TEntity> _entitySet;
        public RepositoryBase()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager>();
            Context = (EcomContext) contextManager.Context;
        }


        public void Add(TEntity obj)
        {           
            Context.Set<TEntity>().Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();  
        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            Context.Set<TEntity>().Remove(obj);
        }

        public void Update(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> GetAll(string include , string include2)
        {
            return Context.Set<TEntity>().Include(include).Include(include2);
        }

        public IEnumerable<TEntity> GetAll(string include)
        {
            return Context.Set<TEntity>().Include(include);
        }
    }
}
