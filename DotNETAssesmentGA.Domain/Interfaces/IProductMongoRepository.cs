using DotNETAssesmentGA.Domain.Entities;

namespace DotNETAssesmentGA.Domain.Interfaces
{
    public interface IProductMongoRepository
    {
        Task<Product> GetByIdAsync(string id);

        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> AddAsync(Product entity);

        Task<Product> UpdateAsync(Product entity);

        Task RemoveAsync(string id);
    }
}