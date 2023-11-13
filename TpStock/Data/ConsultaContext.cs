using TpStock.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TpStock.Data
{
    public class ConsultaContext: DbContext
    {
        public DbSet<User>Users { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Vendedor> Vendedors { get; set; }
        public DbSet<EncargadoStock> EncargadoStock { get; set; }
        public DbSet<Producto> Productos { get; set; }
        

        public ConsultaContext (DbContextOptions<ConsultaContext> options) : base (options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);
            modelBuilder.Entity<Gerente>().HasData(
                new Gerente
                {
                    Name = "Micaela Cassino",
                    Password = "123123123",
                    Email = "micaelacassino@gmail.com",
                    Id = 1,
                }
                );
            modelBuilder.Entity<EncargadoStock>().HasData(
                new EncargadoStock
                {
                    Name = "Emilio Cerro",
                    Password = "321321321",
                    Email = "emiliocerro@gmail.com",
                    Id = 2,
                }
                );
            modelBuilder.Entity<Vendedor>().HasData(
                new Vendedor
                {
                    Name = "Valentin Pairone",
                    Password="123321",
                    Email="valentinpairone@gmail.com",
                    Id = 3,
                }
                );


        }

    }
}
