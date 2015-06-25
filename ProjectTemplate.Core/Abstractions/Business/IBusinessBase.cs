using System.Collections.Generic;

namespace ProjectTemplate.Core.Abstractions.Business
{
    public interface IBusinessBase<TEntity> where TEntity : class
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Dispose();
    }
}
