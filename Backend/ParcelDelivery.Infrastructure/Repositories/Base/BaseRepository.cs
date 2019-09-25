using ParcelDelivery.Domain.Entities.Base;
using ParcelDelivery.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDelivery.Infrastructure.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        protected ICollection<TEntity> _collection;

        public BaseRepository()
        {
            _collection = new List<TEntity>();
        }


        public TEntity Get(int id)
        {
            return _collection.Where(f => f.Id == id).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _collection;
        }


        public void Add(TEntity entity)
        {
            _collection.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (_collection.Contains(entity))
                _collection.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            if (_collection.Contains(entity))
                _collection.Remove(entity);
            _collection.Add(entity);
        }

    }
}
