using AutoMapper;
using DotNETAssesmentGA.Application.DTOs;
using DotNETAssesmentGA.Application.Interfaces;
using DotNETAssesmentGA.Domain.Entities;
using DotNETAssesmentGA.Domain.Interfaces;

namespace DotNETAssesmentGA.Application.Services
{
    public class ProductServiceMongo : IProductServiceMongo
    {
        private readonly IProductMongoRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductServiceMongo(IProductMongoRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            IEnumerable<Product> entities = await _productRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(entities);
        }

        public async Task<ProductDTO> GetByIdAsync(string id)
        {
            Product entity = await _productRepository.GetByIdAsync(id);

            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task AddAsync(ProductDTO dto)
        {
            Product entity = _mapper.Map<Product>(dto);

            entity._Id = "";

            await _productRepository.AddAsync(entity);
        }

        public async Task RemoveAsync(string id)
        {
            await _productRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(ProductDTO dto)
        {
            Product entity = _mapper.Map<Product>(dto);

            await _productRepository.UpdateAsync(entity);
        }
    }
}