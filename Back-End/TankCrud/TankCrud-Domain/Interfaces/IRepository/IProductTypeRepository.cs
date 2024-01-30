using System.Collections.Generic;
using System.Threading.Tasks;
using TankCrud.Models;

namespace TankCrud_Domain.Services
{
    public interface IProductTypeRepository
    {
        Task CreateProductType(ProductType productType);
        Task DeleteProductType(ProductType productType);
        Task<List<ProductType>> ListAllProductType();
        Task UpdtaProductType(ProductType productType);
    }
}