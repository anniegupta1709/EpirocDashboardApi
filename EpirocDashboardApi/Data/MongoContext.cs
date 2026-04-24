using EpirocDashboardApi.Models;
using MongoDB.Driver;

namespace EpirocDashboardApi.Data
{
    public class MongoContext
    {
        private readonly IMongoDatabase _db;

        public MongoContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDB"));
            _db = client.GetDatabase("epirocDB");
        }

        public IMongoCollection<Dashboard> Dashboard =>
            _db.GetCollection<Dashboard>("dashboard");
    }
}
