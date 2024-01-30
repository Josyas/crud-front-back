using AutoMapper;
using System.Threading.Tasks;
using System.Web.Http;
using TankCrud.DTOs;
using TankCrud.Models;
using TankCrud_Domain.Services;

namespace TankCrud.Controllers
{
    public class TankController : ApiController
    {
        private readonly ITankService _tankService;

        public TankController(ITankService tankService)
        {
            _tankService = tankService;
        }

        [Route("CreateTank")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateTank(TankDTO tank)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dto = Mapper.Map<Tank>(tank);

            await _tankService.CreateTank(dto);

            return Ok();
        }

        [Route("GetAllTank")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllTank()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var list = await _tankService.GetAllTank();

            return Ok(list);
        }

        [Route("UpdateTank")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateTank(TankDTO tank)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dto = Mapper.Map<Tank>(tank);

            await _tankService.UpdateTank(dto);

            return Ok();
        }

        [Route("DeleteTank")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteTank(TankDTO tank)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dto = Mapper.Map<Tank>(tank);

            await _tankService.DeleteTank(dto);

            return Ok();
        }
    }
}
