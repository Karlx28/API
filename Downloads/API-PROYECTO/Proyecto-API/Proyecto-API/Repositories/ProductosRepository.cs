using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Proyecto_API.Context;
using Proyecto_API.Model;

namespace Proyecto_API.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly ProductosContext _context;

        public ProductosRepository(ProductosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Productos>> Get() => await _context.Productos.ToListAsync();

        public async Task<Productos> GetById(int id) => await _context.Productos.FindAsync(id);

        public async Task Add(Productos producto) => await _context.Productos.AddAsync(producto);

        public void Update(Productos entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Productos entity) => _context.Productos.Remove(entity);

        public async Task Save() => await _context.SaveChangesAsync();
    }
}
