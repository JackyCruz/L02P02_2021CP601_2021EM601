using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2021CP601_2021EM601.Models
{
    public class clientesDbContext : DbContext
    {
        public clientesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<clientes> clientes { get; set; }
        public DbSet<departamentos> departamentos { get; set; }
        public DbSet<puestos> puestos { get; set; }
    }
}
