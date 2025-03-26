using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    public abstract class Repository<T, TPrimaryKey> : 
        IRepository<T, TPrimaryKey> where T
        : class, IEntity<TPrimaryKey>
    {
        protected readonly DbContext Context;
        private readonly DbSet<T> _entitySet;

        protected Repository(DbContext context)
        {
            Context = context;
            _entitySet = Context.Set<T>();
        }
        /// <summary>
        /// Добавить сущность в базу
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual T Add(T entity)
        {
            var obj = _entitySet.Add(entity);
            return obj.Entity;
        }
        /// <summary>
        /// Добавить сущность в бд
        /// </summary>
        /// <param name="entity">сущность</param>
        /// <returns>Новая запись в бд</returns>
        public virtual async Task<T> AddAsync(T entity)
        {
            return (await _entitySet.AddAsync(entity)).Entity;
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual bool Delete(T entity)
        {
            if(entity is null)return false;
            Context.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        public virtual bool Delete(TPrimaryKey id)
        {
            var obj = _entitySet.Find(id);
            if (obj is null)
                return false;
            _entitySet.Remove(obj);
            return true;
        }

        public virtual T Get(TPrimaryKey id)
        {
            return _entitySet.Find(id);
        }

        public virtual async Task<T> GetAsync(TPrimaryKey id, CancellationToken token = default)
        {
            return await _entitySet.FindAsync((object)id, token);
        }

        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }

        public virtual async Task SaveChangesAsync(CancellationToken token = default)
        {
            await Context.SaveChangesAsync(token);
        }

        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
