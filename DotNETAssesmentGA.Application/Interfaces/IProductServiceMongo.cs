using DotNETAssesmentGA.Application.DTOs;

namespace DotNETAssesmentGA.Application.Interfaces
{
    public interface IProductServiceMongo
    {
        Task<ProductDTO> GetByIdAsync(string id);

        Task<IEnumerable<ProductDTO>> GetAllAsync();

        Task<ProductDTO> AddAsync(ProductDTO dto);

        Task<ProductDTO> UpdateAsync(ProductDTO dto);

        Task RemoveAsync(string id);
    }
}