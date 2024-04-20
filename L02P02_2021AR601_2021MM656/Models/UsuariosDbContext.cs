using Microsoft.EntityFrameworkCore;
using L02P02_2021AR601_2021MM656.Models;

namespace L02P02_2021AR601_2021MM656.Models
{
    public class UsuariosDbContext : DbContext
    {
        public UsuariosDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<usuariosDB> usuariosDB { get; set; }
        public DbSet<puestos> puestos { get; set; }
        public DbSet<departamentos> departamentos { get; set; }
        public DbSet<clientes> clientes { get; set; }
    }
}
