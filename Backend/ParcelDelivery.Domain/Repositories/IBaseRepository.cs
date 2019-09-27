using ParcelDelivery.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDelivery.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        TEntity Get(string id);
        Task<TEntity> GetAsync(string id);

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        void Add(TEntity entity);
        Task AddAsync(TEntity entity);

        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);

        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
