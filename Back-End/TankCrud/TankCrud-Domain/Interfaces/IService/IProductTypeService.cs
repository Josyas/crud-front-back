using System.Collections.Generic;
using System.Threading.Tasks;
using TankCrud.Models;

namespace TankCrud_Domain.Services
{
    public interface IProductTypeService
    {
        Task CreateProductType(ProductType productType);
        Task DeleteProductType(ProductType productType);
        Task<List<ProductType>> GetAllProductType();
        Task UpdateProductType(ProductType productType);
    }
}