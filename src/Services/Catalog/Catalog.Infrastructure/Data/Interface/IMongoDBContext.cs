using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Interface
{
    public interface IMongoDBContext
    {
        IMongoDatabase Database { get; }
    }
}
