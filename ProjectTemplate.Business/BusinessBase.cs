using System;
using System.Collections.Generic;
using ProjectTemplate.Core.Abstractions;
using ProjectTemplate.Core.Abstractions.Business;
using ProjectTemplate.Core.Abstractions.Repository;
using ProjectTemplate.Core.Repository;

namespace ProjectTemplate.Business
{
    public class BusinessBase<TEntity> : IBusinessBase<TEntity> where TEntity : class, IEntityKey<int>, new()
    {
        private readonly IRepositoryBase<TEntity> _repository;
        protected readonly IUnitOfWork Uow;
        public BusinessBase(IRepositoryBase<TEntity> repository, IUnitOfWork uow)
        {
            _repository = repository;
            Uow = uow;
        }

        public void Insert(TEntity obj)
        {
            try
            {
                Uow.BeginTransaction();

                _repository.Insert(obj);

                Uow.Commit();
            }
            catch
            {
                Uow.Rollback();
            }
        }
        public void Update(TEntity obj)
        {
            try
            {
                Uow.BeginTransaction();

                _repository.Update(obj);

                Uow.Commit();
            }
            catch
            {
                Uow.Rollback();
            }
        }

        public void Delete(TEntity obj)
        {
            try
            {
                Uow.BeginTransaction();

                _repository.Delete(obj);

                Uow.Commit();
            }
            catch
            {
                Uow.Rollback();
            }
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
