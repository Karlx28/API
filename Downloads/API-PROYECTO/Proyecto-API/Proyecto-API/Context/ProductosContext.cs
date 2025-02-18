using Proyecto_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_API.Context
{
    public class ProductosContext : DbContext
    {
        public ProductosContext(DbContextOptions<ProductosContext> options) : base(options)
        {
        }
        public DbSet<Productos> Productos { get; set; }
    }
}
