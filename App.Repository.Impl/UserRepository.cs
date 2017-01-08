using App.Context;
using App.Entity;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace App.Repository.Impl
{
    public class UserRepository<TEntity> : IUserRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly IUserContext userContext;

        public UserRepository(IUserContext userContext)
        {
            this.userContext = userContext;
        }

        private IDbSet<TEntity> GetEntities()
        {
            return this.userContext.Set<TEntity>();
        }

        public TEntity GetById(Guid id)
        {
            return GetEntities().AsQueryable().SingleOrDefault(x => x.Id == id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> criteria)
        {
            return GetEntities().SingleOrDefault(criteria);
        }

        public void Update(TEntity entity)
        {
            var original = GetById(entity.Id);

            if (original != null)
            {
                userContext.Entry(original).CurrentValues.SetValues(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            var original = GetById(entity.Id);
            if (original != null)
            {
                GetEntities().Remove(original);
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return GetEntities().AsQueryable();
        }
        public IQueryable<TEntity> Search<TOrderBy>(Expression<Func<TEntity, bool>> criteria,
                    Expression<Func<TEntity, TOrderBy>> orderBy,
                    int pageIndex, int pageSize, out int total, SortOrder sortOrder = SortOrder.Ascending)
        {
            total = GetEntities().AsQueryable().Count();//reference

            if (sortOrder == SortOrder.Ascending)
            {
                return GetEntities().AsQueryable()
                        .Where(criteria)
                        .OrderBy(orderBy)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize);
            }
            return GetEntities().AsQueryable().Where(criteria).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public TEntity Insert(TEntity entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            return GetEntities().Add(entity);
        }

        public void SaveChanges()
        {
            this.userContext.SaveChanges();
        }

        public TEntity GetNew()
        {
            return new TEntity();
        }

        public void Dispose()
        {
            if (this.userContext != null)
            {
                this.userContext.Dispose();
            }
        }
    }
}
