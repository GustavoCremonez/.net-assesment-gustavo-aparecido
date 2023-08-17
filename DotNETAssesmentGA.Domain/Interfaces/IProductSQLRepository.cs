using DotNETAssesmentGA.Domain.Entities;

namespace DotNETAssesmentGA.Domain.Interfaces
{
    public interface IProductSQLRepository
    {
        Task<Product> GetByIdAsync(int id);

        Task<IEnumerable<Product>> GetAllAsync();

        Task AddAsync(Product entity);

        Task UpdateAsync(Product entity);

        Task RemoveAsync(Product entity);
    }
}