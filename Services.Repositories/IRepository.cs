using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Base;

namespace Services.Repositories
{
    public interface IRepository<T, TPrimaryKey>
        where T: IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void SaveChanges();
        
        /// <summary>
        /// Сохранить изменения
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task SaveChangesAsync(CancellationToken token = default);

        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);  
        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(T entity);
        /// <summary>
        /// Удалить 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(TPrimaryKey id);

        /// <summary>
        /// Получить сущность по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<T> GetAsync(TPrimaryKey id, CancellationToken token = default);

        /// <summary>
        /// Получить сущность
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(TPrimaryKey id);
        
        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <param name="noTracking">ключь для AsNoTracking</param>
        /// <returns></returns>
        IQueryable<T> GetAll(bool noTracking = false);
        
        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <param name="noTracking"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<List<T>> GetAllAsync(bool noTracking = false, CancellationToken token = default);
    }
}
