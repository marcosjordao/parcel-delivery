using MongoDB.Bson;
using MongoDB.Driver;
using ParcelDelivery.Domain.Entities.Base;
using ParcelDelivery.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDelivery.Infrastructure.Repositories.Base
{
    public class MongoRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        private readonly IMongoDatabase _database;
        public readonly IMongoCollection<TEntity> _collection;

        public MongoRepository(string connectionString, string databaseName)
        {

            // MongoDB Atlas
            var client = new MongoDB.Driver.MongoClient(connectionString);
            //var databaseName = "Delivery";

            _database = client.GetDatabase(databaseName);
            _collection = _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public TEntity Get(string id)
        {
            return _collection.Find(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public async Task<TEntity> GetAsync(string id)
        {
            return await _collection.Find(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _collection.Find(new BsonDocument()).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public void Add(TEntity entity)
        {
            _collection.InsertOne(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _collection.ReplaceOne(x => x.Id.Equals(entity.Id),
                                   entity,
                                   new UpdateOptions { IsUpsert = true });
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id),
                                              entity,
                                              new UpdateOptions { IsUpsert = true });
        }

        public void Delete(TEntity entity)
        {
            _collection.DeleteOne(x => x.Id.Equals(entity.Id));
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _collection.DeleteOneAsync(x => x.Id.Equals(entity.Id));
        }
    }
}
