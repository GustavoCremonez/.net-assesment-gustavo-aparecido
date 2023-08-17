using DotNETAssesmentGA.Application.DTOs;

namespace DotNETAssesmentGA.Application.Interfaces
{
    public interface IProductServiceSQL
    {
        Task<ProductDTO> GetByIdAsync(int id);

        Task<IEnumerable<ProductDTO>> GetAllAsync();

        Task AddAsync(ProductDTO dto);

        Task UpdateAsync(ProductDTO dto);

        Task RemoveAsync(int id);
    }
}