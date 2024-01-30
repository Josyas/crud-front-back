using System.Collections.Generic;
using System.Threading.Tasks;
using TankCrud.Models;

namespace TankCrud_Domain.Services
{
    public class TankService : ITankService
    {
        private readonly ITankRepository _tankRepository;

        public TankService(ITankRepository tankRepository)
        {
            _tankRepository = tankRepository;
        }

        public async Task CreateTank(Tank tank)
        {
            Tank tankCreateObjct = new Tank()
            {
                Capacity = tank.Capacity,
                ProductTypeId = tank.ProductTypeId,
                Deposit = tank.Deposit
            };

            await _tankRepository.CreateTank(tankCreateObjct);
        }

        public async Task UpdateTank(Tank tank)
        {
            await _tankRepository.UpdtaTank(tank);
        }

        public async Task DeleteTank(Tank tank)
        {
            await _tankRepository.DeleteTank(tank);
        }

        public async Task<List<Tank>> GetAllTank()
        {
            var list = await _tankRepository.ListAllTank();

            return list;
        }
    }
}
