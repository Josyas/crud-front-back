using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TankCrud.Models;
using TankCrud_Domain.Services;
using TankCrud_Infrastructure.Database;

namespace TankCrud_Infrastructure.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly AppDbContext _appContext;

        public ProductTypeRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task CreateProductType(ProductType productType)
        {
            await _appContext.ProductTypes.AddAsync(productType);

            await SaveAsync();
        }

        public async Task UpdtaProductType(ProductType productType)
        {
            _appContext.Update(productType);

            await SaveAsync();
        }

        public async Task DeleteProductType(ProductType productType)
        {
            _appContext.Remove(productType);

            await SaveAsync();
        }

        public async Task<List<ProductType>> ListAllProductType()
        {
            var list = await _appContext.ProductTypes.AsNoTracking().OrderByDescending(x => x.Id).ToListAsync();

            return list;
        }

        private async Task SaveAsync()
        {
            await _appContext.SaveChangesAsync();
        }
    }
}
