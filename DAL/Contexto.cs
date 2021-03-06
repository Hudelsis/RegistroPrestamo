
using Microsoft.EntityFrameworkCore;
using RegistroPrestamos.Entidades; 

namespace RegistroPrestamos.DAL
{

    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Prestamos> Prestamos{ get; set; } 

        public DbSet<Moras> Moras{get; set;}
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source = Data/Prestamos.db");
        }
    }
}
