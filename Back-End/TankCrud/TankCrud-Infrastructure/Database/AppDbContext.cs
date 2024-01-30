using Microsoft.EntityFrameworkCore;
using TankCrud.Models;
using TankCrud_Infrastructure.EntitiesConfiguration;

namespace TankCrud_Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Tank> Tanks { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var conexao = "conexão do banco";
            options.UseSqlServer(conexao);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductTypeMap());
            modelBuilder.ApplyConfiguration(new TankMap());
        }
    }
}
