using AutoMapper;
using DotNETAssesmentGA.Application.DTOs;
using DotNETAssesmentGA.Application.Interfaces;
using DotNETAssesmentGA.Application.Mappings;
using DotNETAssesmentGA.Domain.Entities;
using DotNETAssesmentGA.Domain.Interfaces;

namespace DotNETAssesmentGA.Application.Services
{
    public class ProductServiceMongo : IProductServiceMongo
    {
        private readonly IProductMongoRepository _productRepository;
        private readonly Mapper _mapper;
        private readonly IMessengerSender _messengerSender;

        public ProductServiceMongo(IProductMongoRepository productRepository, IMapper mapper, IMessengerSender messengerSender)
        {
            _productRepository = productRepository;
            _messengerSender = messengerSender;

            DomainToDTOMappingProfile mapperProfile = new DomainToDTOMappingProfile();
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(mapperProfile));
            _mapper = new Mapper(mapperConfiguration);
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

        public async Task<ProductDTO> AddAsync(ProductDTO dto)
        {
            Product entity = _mapper.Map<Product>(dto);

            entity._Id = "";

            Product result = await _productRepository.AddAsync(entity);
            ProductDTO dtoResult = _mapper.Map<ProductDTO>(result);

            _messengerSender.QueueMessage(dtoResult);
            return dtoResult;
        }

        public async Task RemoveAsync(string id)
        {
            await _productRepository.RemoveAsync(id);
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO dto)
        {
            Product entity = _mapper.Map<Product>(dto);

            Product result = await _productRepository.UpdateAsync(entity);
            ProductDTO dtoResult = _mapper.Map<ProductDTO>(result);

            return dtoResult;
        }
    }
}