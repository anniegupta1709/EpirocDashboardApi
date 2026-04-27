using EpirocDashboardApi.Models;
using MongoDB.Driver;

namespace EpirocDashboardApi.Data
{
    public class MongoContext
    {
        private readonly IMongoDatabase _db;

        public MongoContext(IConfiguration config)
        {
            var connectionString =
                Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING")
                ?? config.GetConnectionString("MongoDB");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("MongoDB connection string is missing");
            }

            var client = new MongoClient(connectionString);
            _db = client.GetDatabase("epirocDB");
        }


        public IMongoCollection<Dashboard> Dashboard =>
            _db.GetCollection<Dashboard>("dashboard");
    }
}
