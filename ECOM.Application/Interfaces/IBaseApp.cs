

using System.Collections.Generic;

namespace ECOM.Application.Interfaces
{
    public interface IBaseApp<TEntity> where TEntity : class
    {
        void AddEntity(TEntity entity);

        void UpdateEntity(TEntity entity);

        void DeleteEntity(TEntity entity);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(string include);
        IEnumerable<TEntity> GetAll(string include , string include2);

        TEntity GetEntityById(int id);

        void Dispose();
    }
}
