using System;
using MongoDB.Driver;
using todo_clean.domain.entities;
using todo_clean.shared.db;

namespace todo_clean.infra.context
{
    public class MongoDbContext
    {
        private IMongoDatabase _database { get; }

        public MongoDbContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConfigurationDb.connectionString));

                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(ConfigurationDb.databaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public IMongoCollection<CustomerEntity> Customer
        {
            get
            {
                return _database.GetCollection<CustomerEntity>("customer");
            }
        }
    }
}