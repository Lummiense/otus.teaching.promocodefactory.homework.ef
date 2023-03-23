﻿using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain;
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
        protected readonly DbContext _dbContext;
        protected EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получить из БД список всех сущностей
        /// </summary>
        /// <returns>Список сущностей</returns>
        public Task<IEnumerable<T>> GetAllAsync()
        {
            var result = _dbContext.Set<T>().ToList().AsEnumerable();
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
        public Task AddAsync(T entity)
        {
            var result = _dbContext.Add(entity);
            return Task.FromResult(result);
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
            return Task.FromResult(result);
        }

        /// <summary>
        /// Обновить данные сущности в БД
        /// </summary>
        /// <param name="entity">Обновленная сущность</param>
        /// <returns>???</returns>
        public Task UpdateAsync(T entity)
        {
            var result = _dbContext.Update(entity);
            return Task.FromResult(result);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        
    }
}