using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using TankCrud.DTOs;
using TankCrud.Models;
using TankCrud_Domain.Services;

namespace TankCrud.Controllers
{
    public class ProductTypeController : ApiController
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [Route("CreateProductType")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateProductType(ProductTypeDTO productType)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            try
            {
                var dto = Mapper.Map<ProductType>(productType);

                await _productTypeService.CreateProductType(dto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAllProductType")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllProductType()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var list = await _productTypeService.GetAllProductType();

            return Ok(list);
        }

        [Route("UpdateProductType")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateProductType(ProductType productType)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _productTypeService.UpdateProductType(productType);

            return Ok();
        }

        [Route("DeleteProductType")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProductType(ProductTypeDTO productType)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dto = Mapper.Map<ProductType>(productType);

            await _productTypeService.DeleteProductType(dto);

            return Ok();
        }
    }
}
