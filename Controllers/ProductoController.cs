using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Utilies;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class ProductoController : Controller
    {

        private readonly IApiService _api;

        public ProductoController(IApiService apiService)
        {
            _api = apiService;
        }   


        // GET: ProductoController  
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Producto> productos = await _api.GetProductos();
                return View(productos);
            } catch (Exception e)
            {
                return View(new List<Producto>());
            }
        }

        // GET: ProductoController/Details/Id
        public async Task<ActionResult> Details(int IdProducto)
        {
            var producto = await _api.GetProducto(IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            var result = await _api.AddProducto(producto);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int IdProducto)
        {
            var producto = await _api.GetProducto(IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        // POST: ProductoController/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Producto producto)
        {
            var productoEditado = await _api.UpdateProducto(producto.IdProducto, producto);
            if (productoEditado != null)
            {
                return RedirectToAction(nameof(Index));
            }   
            return View(productoEditado);  
        }


        // GET: ProductoController/Delete/5
        public ActionResult Delete(int IdProducto)
        {
            var productoEliminado = _api.DeleteProducto(IdProducto);
            return RedirectToAction(nameof(Index));

        }

    }
}
