using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TankCrud.Models;
using TankCrud_Domain.Services;
using TankCrud_Infrastructure.Database;

namespace TankCrud_Infrastructure.Repositories
{
    public class TankRepository : ITankRepository
    {
        private readonly AppDbContext _appContext;

        public TankRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task CreateTank(Tank tank)
        {
            await _appContext.Tanks.AddAsync(tank);

            await SaveAsync();
        }

        public async Task UpdtaTank(Tank tank)
        {
            _appContext.Update(tank);

            await SaveAsync();
        }

        public async Task DeleteTank(Tank tank)
        {
            _appContext.Remove(tank);

            await SaveAsync();
        }

        public async Task<List<Tank>> ListAllTank()
        {
            var list = await _appContext.Tanks.Include(tank => tank.ProductType).AsNoTracking().OrderByDescending(tank => tank.Id).ToListAsync();

            return list;
        }

        private async Task SaveAsync()
        {
            await _appContext.SaveChangesAsync();
        }
    }
}
