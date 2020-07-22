using System.Threading.Tasks;
using localapi.Infrastructure.Models;
using MongoDB.Driver;

namespace localapi.Infrastructure.Implementations
{
    public class PullRequestRepository : IPullRequestRepository
    {
        private string _dbName;
        private string _connectionString;
        private string _collectionName;
        public PullRequestRepository()
        {
            _connectionString = "mongodb://172.21.0.4:27017";
            _dbName = "LocalApiDb";
            _collectionName = "PullRequests";
        }
        public async Task AddAsync(DbPullRequest pullRequest)
        {
            MongoClient client = new MongoClient(_connectionString);
            IMongoDatabase database =  client.GetDatabase(_dbName);
            var collection = database.GetCollection<DbPullRequest>(_collectionName);
            await collection.InsertOneAsync(pullRequest);
        }
    }
}