
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ECOM.Domain.Services
{
    public class ServiceBase<TEntity> :  IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        private IUnitOfWork _unitOfWork;
        public ServiceBase(IRepositoryBase<TEntity> repository , IUnitOfWork unitOfWork )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(TEntity obj)
        {
            _unitOfWork.BeginTransaction();
            _repository.Add(obj);
            _unitOfWork.Commit();
            _unitOfWork.Dispose();
        }



        public IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> entities =  _repository.GetAll();
            _unitOfWork.Dispose();
            return entities;

        }

        public IEnumerable<TEntity> GetAll(string include)
        {
            IEnumerable<TEntity> entities = _repository.GetAll(include);
            _unitOfWork.Dispose();
            return entities;
        }
        public IEnumerable<TEntity> GetAll(string include , string include2)
        {
            IEnumerable<TEntity> entities = _repository.GetAll(include , include2);
            _unitOfWork.Dispose();
            return entities;
        }

        public TEntity GetById(int id)
        {
            TEntity entity =  _repository.GetById(id);
            _unitOfWork.Dispose();
            return entity;
        }

        public void Remove(TEntity obj)
        {
            _unitOfWork.BeginTransaction();
            _repository.Remove(obj);
            _unitOfWork.Commit();
            _unitOfWork.Dispose();
        }

        public void Update(TEntity obj)
        {
            _unitOfWork.BeginTransaction();
            _repository.Update(obj);
            _unitOfWork.Commit();
            _unitOfWork.Dispose();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
