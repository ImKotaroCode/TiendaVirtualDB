using Microsoft.AspNetCore.Mvc;
using MiTiendaVirtual.Models;

namespace MiTiendaVirtual.Controllers
{
    public class PedidoController : Controller
    {

        public IActionResult MostrarPedidos(int Id)
        {
            Pedido pedido = new Pedido();

            using (TiendaVirtualDbContext BD = new TiendaVirtualDbContext())
            {
                var listapedidos = (from p in BD.Pedidos
                                    where p.Id == Id
                                    select new Pedido
                                    {
                                        Id = p.Id,
                                        FechaHora = p.FechaHora,
                                        Total = p.Total,
                                        Estado = p.Estado
                                    }).ToList();

                if (listapedidos.Count > 0)
                {
                    pedido = listapedidos.First();
                }
            }

            return View(pedido);
        }
    }
}
