using Microsoft.AspNetCore.Mvc;
using MiTiendaVirtual.Models;

namespace MiTiendaVirtual.Controllers
{
    public class ProductosController : Controller
    {
        //GET
        //dominio:puerto/Productos
        //dominio:puerto/Productos/Index
        public IActionResult Index()
        {
            List<Producto> listaProductos = new List<Producto>();

            using (TiendaVirtualDbContext BD = new TiendaVirtualDbContext())
            {
                listaProductos = (from p in BD.Productos select p).ToList();
            }

            return View(listaProductos);
        }
    }

}
