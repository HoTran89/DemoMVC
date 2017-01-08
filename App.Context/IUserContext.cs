using App.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace App.Context
{
    public interface IUserContext : IDisposable
    {
        int SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : BaseEntity;
    }
}
