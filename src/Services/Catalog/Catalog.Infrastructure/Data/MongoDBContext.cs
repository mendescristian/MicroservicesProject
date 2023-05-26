using Catalog.Infrastructure.Data.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public class MongoDBContext : IMongoDBContext
    {
        public IMongoDatabase Database { get; private set; }

        private readonly IMongoClient _client;

        public MongoDBContext(IConfiguration configuration)
        {
            var url = new MongoUrl(configuration.GetSection("DatabaseSettings:ConnectionString").Value);

            _client = new MongoClient(configuration.GetSection("DatabaseSettings:ConnectionString").Value);

            Database = _client.GetDatabase(url.DatabaseName);
        }

        public async Task<IClientSessionHandle> CreateSessionAsync()
            => await Database.Client.StartSessionAsync();
    }
}
