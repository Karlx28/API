using Proyecto_API.Controllers;
using Proyecto_API.Model;

namespace Proyecto_API.Repositories
{
    public interface IProductosRepository
    {
        Task<IEnumerable<Productos>> Get();
        Task<Productos> GetById(int id);
        Task Add(Productos producto);
        void Update(Productos producto);
        void Delete(Productos entity);
        Task Save();
    }
}