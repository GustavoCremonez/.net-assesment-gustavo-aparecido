using DotNETAssesmentGA.Domain.Entities;
using DotNETAssesmentGA.Domain.Interfaces;
using MongoDB.Driver;

namespace DotNETAssesmentGA.Infra.Data.Repositories
{
    public class ProductMongoRepository : IProductMongoRepository
    {
        private readonly IMongoCollection<Product> _productColletion;

        public ProductMongoRepository(IMongoDatabaseConfiguration mongoDatabaseConfiguration)
        {
            MongoClient client = new MongoClient(mongoDatabaseConfiguration.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoDatabaseConfiguration.DatabaseName);

            _productColletion = database.GetCollection<Product>("Products");
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productColletion.Find(prod => true).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _productColletion.Find(prod => prod._Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Product entity)
        {
            await _productColletion.InsertOneAsync(entity);
        }

        public async Task RemoveAsync(string id)
        {
            await _productColletion.DeleteOneAsync(prod => prod._Id == id);
        }

        public async Task UpdateAsync(string id, Product entity)
        {
            await _productColletion.ReplaceOneAsync(prod => prod._Id == id, entity);
        }
    }
}