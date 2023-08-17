using DotNETAssesmentGA.Domain.Entities;

namespace DotNETAssesmentGA.Domain.Interfaces
{
    public interface IProductMongoRepository
    {
        Task<Product> GetByIdAsync(string id);

        Task<IEnumerable<Product>> GetAllAsync();

        Task AddAsync(Product entity);

        Task UpdateAsync(Product entity);

        Task RemoveAsync(string id);
    }
}