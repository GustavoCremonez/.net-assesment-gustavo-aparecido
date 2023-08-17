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
            Product? entity = await _productColletion.Find(prod => prod._Id == id).FirstOrDefaultAsync();

            if (entity != null)
                return entity;

            throw new ApplicationException("Product not found, Try again!");
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await _productColletion.InsertOneAsync(entity);

            return entity;
        }

        public async Task RemoveAsync(string id)
        {
            await _productColletion.DeleteOneAsync(prod => prod._Id == id);
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            await _productColletion.ReplaceOneAsync(prod => prod._Id == entity._Id, entity);

            return entity;
        }
    }
}