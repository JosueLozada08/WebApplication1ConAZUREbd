using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IApiService
    {
        Task<List<Producto>> GetProductos();
        Task<Producto> GetProducto(int id);
        Task<bool> AddProducto(Producto producto);
        Task<bool> UpdateProducto(int id, Producto producto);
        Task<bool> DeleteProducto(int id);
    }
}
