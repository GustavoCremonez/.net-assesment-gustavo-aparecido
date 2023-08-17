using DotNETAssesmentGA.Domain.Entities;

namespace DotNETAssesmentGA.Domain.Interfaces
{
    public interface IProductSQLRepository
    {
        Task<Product> GetByIdAsync(int id);

        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> AddAsync(Product entity);

        Task<Product> UpdateAsync(Product entity);

        Task RemoveAsync(Product entity);
    }
}