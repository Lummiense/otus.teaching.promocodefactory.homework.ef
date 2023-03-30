using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories
{
        public class EfRepository <T> : IRepository<T>
      where T : BaseEntity
    {
        protected readonly DataContext _dbContext;
        public EfRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получить из БД список всех сущностей
        /// </summary>
        /// <returns>Список сущностей</returns>
        public Task<List<T>> GetAllAsync()
        {
            var result = _dbContext.Set<T>().ToList();            
            return Task.FromResult(result);
        }

        /// <summary>
        /// Получить сущность из БД по заданному id
        /// </summary>
        /// <param name="id">id интересующей сущности</param>
        /// <returns>Интереующая сущность</returns>
        public Task<T> GetByIdAsync(Guid id)
        {
            var result = _dbContext.Set<T>().FirstOrDefault(x=>x.Id==id);
            return Task.FromResult(result);
        }

        /// <summary>
        /// Добавить новую сущность в БД
        /// </summary>
        /// <param name="entity">Сущность для добавления</param>
        /// <returns>???</returns>
        public Task <Guid> AddAsync(T entity) 
        {
            var result = _dbContext.Add(entity);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(result.Entity.Id);
        }

        /// <summary>
        /// Удалить сущность из БД
        /// </summary>
        /// <param name="id">id сущности, которую нужно удалить</param>
        /// <returns>???</returns>
        public Task DeleteAsync(Guid id)
        {
            var entity = _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
            var result = _dbContext.Remove(entity);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(result);
        }

        /// <summary>
        /// Обновить данные сущности в БД
        /// </summary>
        /// <param name="entity">Обновленная сущность</param>
        /// <returns>???</returns>
        public Task <Guid> UpdateAsync(T entity)
        {
            var result = _dbContext.Update(entity);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(result.Entity.Id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        
    }
}
