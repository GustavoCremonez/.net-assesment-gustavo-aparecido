using AutoMapper;
using DotNETAssesmentGA.Application.DTOs;
using DotNETAssesmentGA.Application.Interfaces;
using DotNETAssesmentGA.Application.Mappings;
using DotNETAssesmentGA.Domain.Entities;
using DotNETAssesmentGA.Domain.Interfaces;

namespace DotNETAssesmentGA.Application.Services
{
    public class ProductServiceSQL : IProductServiceSQL
    {
        private readonly IProductSQLRepository _productSQLRepository;
        private readonly IMessengerSender _messengerSender;
        private readonly Mapper _mapper;

        public ProductServiceSQL(IProductSQLRepository productSQLRepository, IMessengerSender messengerSender)
        {
            _productSQLRepository = productSQLRepository;
            _messengerSender = messengerSender;

            DomainToDTOMappingProfile mapperProfile = new DomainToDTOMappingProfile();
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(mapperProfile));
            _mapper = new Mapper(mapperConfiguration);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            IEnumerable<Product> entities = await _productSQLRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(entities);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            Product entity = await _productSQLRepository.GetByIdAsync(id);

            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<ProductDTO> AddAsync(ProductDTO dto)
        {
            dto.Id = 0;
            dto._Id = "";

            Product entity = _mapper.Map<Product>(dto);

            Product result = await _productSQLRepository.AddAsync(entity);

            ProductDTO dtoResult = _mapper.Map<ProductDTO>(result);
            _messengerSender.QueueMessage(dtoResult);

            return dtoResult;
        }

        public async Task RemoveAsync(int id)
        {
            Product entity = await _productSQLRepository.GetByIdAsync(id);

            await _productSQLRepository.RemoveAsync(entity);
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO dto)
        {
            Product entity = _mapper.Map<Product>(dto);

            Product result = await _productSQLRepository.AddAsync(entity);

            ProductDTO dtoResult = _mapper.Map<ProductDTO>(result);

            return dtoResult;
        }
    }
}