using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectTemplate.Core.Repository;

namespace ProjectTemplate.Core.EF
{
    public class EFRepository : IRepository
    {

        //private static readonly ICommandBuilder CommandBuilder = new EntityFrameworkCommandBuilder();
        private readonly DbContext _dbContext;

        //protected readonly IUnitOfWork UnitOfWork;

        public EFRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        private DbSet<T> Set<T>() where T : class, new()
        {
            return _dbContext.Set<T>();
        }

        public  void Insert<T>(T entity) where T : class, new()
        {
            //_dbContext.Set<T>().Add(entity);
            SetState(entity, EntityState.Added);
        }

        public  void Update<T>(T entity) where T : class, new()
        {
            SetState(entity, EntityState.Modified);
        }

        public  void Delete<T>(T entity) where T : class, new()
        {
            SetState(entity, EntityState.Deleted);
        }

        public  IQueryable<T> Select<T>() where T : class, new()
        {
            return Set<T>();
        }

        public IList<T> Query<T>(string spNameOrSql, IDictionary<string, object> args = null, bool rawSql = false) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void NonQuery(string spNameOrSql, IDictionary<string, object> args = null, bool rawSql = false)
        {
            throw new NotImplementedException();
        }

        //public void Flush()
        //{
        //    UnitOfWork.Commit();
        //}


        private void SetState<T>(T entity, EntityState state) where T : class, new()
        {
            var entry = _dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set<T>().Attach(entity);
            }
            entry.State = state;

            _dbContext.SaveChanges();
        }
    }
}