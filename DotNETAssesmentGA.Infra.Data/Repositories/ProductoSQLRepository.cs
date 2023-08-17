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

            throw new ApplicationException("Não foi encontrado o produto desejado, tente novamente!");
        }

        public async Task AddAsync(Product entity)
        {
            _contextRepository.Add(entity);

            await _contextRepository.SaveChangesAsync();
        }

        public async Task RemoveAsync(Product entity)
        {
            _contextRepository.Remove(entity);

            await _contextRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _contextRepository.Update(entity);

            await _contextRepository.SaveChangesAsync();
        }
    }
}