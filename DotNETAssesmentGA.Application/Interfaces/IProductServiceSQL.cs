using DotNETAssesmentGA.Application.DTOs;

namespace DotNETAssesmentGA.Application.Interfaces
{
    public interface IProductServiceSQL
    {
        Task<ProductDTO> GetByIdAsync(int id);

        Task<IEnumerable<ProductDTO>> GetAllAsync();

        Task<ProductDTO> AddAsync(ProductDTO dto);

        Task<ProductDTO> UpdateAsync(ProductDTO dto);

        Task RemoveAsync(int id);
    }
}