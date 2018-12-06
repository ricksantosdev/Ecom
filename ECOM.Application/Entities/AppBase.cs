

using System.Collections.Generic;
using ECOM.Application.Interfaces;
using ECOM.Domain.Interfaces.Repositories;
using Microsoft.Practices.ServiceLocation;
using ECOM.Domain.Interfaces.Services;
namespace ECOM.Application.Entities
{
    public class AppBase<T> : IBaseApp<T> where T : class
    {

        private IServiceBase<T> _serviceBase;

        public AppBase(IServiceBase<T> service)
        {
            _serviceBase = service;
        }

        public void DeleteEntity(T entity)
        {
            _serviceBase.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public T GetEntityById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public void AddEntity(T entity)
        {
            _serviceBase.Add(entity);
        }

        public void UpdateEntity(T entity)
        {
            _serviceBase.Update(entity);
        }

        public IEnumerable<T> GetAll(string include)
        {
            return _serviceBase.GetAll(include);
        }
        public IEnumerable<T> GetAll(string include , string include2)
        {
            return _serviceBase.GetAll(include , include2);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
