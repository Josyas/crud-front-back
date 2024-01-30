using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TankCrud.Models;

namespace TankCrud_Domain.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task CreateProductType(ProductType productType)
        {
            var itemDuplicate = await ItemDuplicate(productType);

            if (!itemDuplicate)
            {
                ProductType ProductTypeCreateObjct = new ProductType()
                {
                    Name = productType.Name
                };
                
                await _productTypeRepository.CreateProductType(ProductTypeCreateObjct);
            }
            else
            {
                throw new Exception("tente outro nome.");
            }
        }

        public async Task UpdateProductType(ProductType productType)
        {
            await _productTypeRepository.UpdtaProductType(productType);
        }

        public async Task<List<ProductType>> GetAllProductType()
        {
            var list = await _productTypeRepository.ListAllProductType();

            return list;
        }

        public async Task DeleteProductType(ProductType productType)
        {
            await _productTypeRepository.DeleteProductType(productType);
        }

        private async Task<Boolean> ItemDuplicate(ProductType productType)
        {
            var list = await _productTypeRepository.ListAllProductType();

            var duplicate = list.Exists(x => x.Name == productType.Name);

            return duplicate;
        }
    }
}
