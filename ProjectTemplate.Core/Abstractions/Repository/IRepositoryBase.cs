using System.Collections.Generic;

namespace ProjectTemplate.Core.Abstractions.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        //void Save(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        void Dispose();
    }
}
