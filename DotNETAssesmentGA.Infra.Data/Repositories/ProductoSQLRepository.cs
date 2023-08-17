using DotNETAssesmentGA.Domain.Entities;
using DotNETAssesmentGA.Domain.Interfaces;
using DotNETAssesmentGA.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DotNETAssesmentGA.Infra.Data.Repositories
{
    public class ProductoSQLRepository : IProductSQLRepository
    {
        private readonly ApplicationDbContextSQL _contextRepository;

        public ProductoSQLRepository(ApplicationDbContextSQL contextRepository)
        {
            _contextRepository = contextRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _contextRepository.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            Product? entity = await _contextRepository.Products.FirstOrDefaultAsync(prod => prod.Id == id);

            if (entity != null)
                return entity;

            throw new ApplicationException("Product not found, Try again!");
        }

        public async Task<Product> AddAsync(Product entity)
        {
            Product registeredEntity = _contextRepository.Add(entity).Entity;

            await _contextRepository.SaveChangesAsync();

            return registeredEntity;
        }

        public async Task RemoveAsync(Product entity)
        {
            _contextRepository.Remove(entity);

            await _contextRepository.SaveChangesAsync();
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            Product updatedEntity = _contextRepository.Update(entity).Entity;

            await _contextRepository.SaveChangesAsync();

            return updatedEntity;
        }
    }
}