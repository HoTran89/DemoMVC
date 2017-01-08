using App.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Data.Entity.Infrastructure;

namespace App.Context
{
    public class UserContext : DbContext, IUserContext
    {
        public UserContext() : base("UserContext")
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        IDbSet<TEntity> IUserContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            return base.Entry(entity);
        }
    }
}
