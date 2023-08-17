﻿using AutoMapper;
using DotNETAssesmentGA.Application.DTOs;
using DotNETAssesmentGA.Application.Interfaces;
using DotNETAssesmentGA.Domain.Entities;
using DotNETAssesmentGA.Domain.Interfaces;

namespace DotNETAssesmentGA.Application.Services
{
    public class ProductServiceSQL : IProductServiceSQL
    {
        private readonly IProductSQLRepository _productSQLRepository;
        private readonly IMapper _mapper;

        public ProductServiceSQL(IProductSQLRepository productSQLRepository, IMapper mapper)
        {
            _productSQLRepository = productSQLRepository;
            _mapper = mapper;
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

        public async Task AddAsync(ProductDTO dto)
        {
            Product entity = _mapper.Map<Product>(dto);

            entity._Id = "";

            await _productSQLRepository.AddAsync(entity);
        }

        public async Task RemoveAsync(int id)
        {
            Product entity = await _productSQLRepository.GetByIdAsync(id);

            await _productSQLRepository.RemoveAsync(entity);
        }

        public async Task UpdateAsync(ProductDTO dto)
        {
            Product entitie = _mapper.Map<Product>(dto);

            await _productSQLRepository.UpdateAsync(entitie);
        }
    }
}