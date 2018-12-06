

using System.Collections.Generic;

namespace ECOM.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        IEnumerable<TEntity> GetAll(string include);
        IEnumerable<TEntity> GetAll(string include , string include2);

        void Dispose();

    }
}
