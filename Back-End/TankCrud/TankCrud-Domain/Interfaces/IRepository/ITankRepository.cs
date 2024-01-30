using System.Collections.Generic;
using System.Threading.Tasks;
using TankCrud.Models;

namespace TankCrud_Domain.Services
{
    public interface ITankRepository
    {
        Task CreateTank(Tank tank);
        Task DeleteTank(Tank tank);
        Task<List<Tank>> ListAllTank();
        Task UpdtaTank(Tank tank);
    }
}