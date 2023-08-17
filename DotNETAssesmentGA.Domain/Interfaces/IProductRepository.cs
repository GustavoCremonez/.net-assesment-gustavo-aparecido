using DotNETAssesmentGA.Domain.Entities;

namespace DotNETAssesmentGA.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync();

        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> AddAsync(Product entity);

        Task<Product> UpdateAsync(Product entity);

        Task RemoveAsync(Product entity);
    }
}