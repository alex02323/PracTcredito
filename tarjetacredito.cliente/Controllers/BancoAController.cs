using Microsoft.AspNetCore.Mvc;
using System;
using tarjetacredito.cliente.Models;
using tarjetacredito.cliente.Servicios;


namespace tarjetacredito.cliente.Controllers
{
    public class BancoAController : Controller
    {
        private readonly Itarjeta _servicioApi;

        public BancoAController(Itarjeta servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public async Task<IActionResult> Index()
        {
            //para este ejemplo se enviara el id del cliente manual y proceder con el resto automatico.
            Cliente cliente = await _servicioApi.Client(1);
            var nombre = cliente.Nombres + " " + cliente.Apellidos;
            ViewBag.Accion = nombre;
            List<Tarjeta> tarjeta = await _servicioApi.ListaTarjetas(1);
            return View(tarjeta);
        }

        public async Task<IActionResult> Pagar(int id)
        {
            Movimientos pago = new();
            pago.IdTarjeta = id;
            return View(pago);
        }

        public async Task<IActionResult> Comprar(int id)
        {
            Movimientos compra = new();
            compra.IdTarjeta = id;
            return View(compra);
        }

        public async Task<IActionResult> EstadoCuenta(int id)
        {
            return View();
        }

        public async Task<IActionResult> Movimientos(int id)
        {
            List<Movimientos> tarjeta = await _servicioApi.MovimientosTar(id);

            return View(tarjeta);
        }



        [HttpPost]
        public async Task<IActionResult> PagarTc(Movimientos movimineto)
        {
            bool respuesta;

            respuesta = await _servicioApi.pagar(movimineto);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ComprarTc(Movimientos movimineto)
        {
            bool respuesta;

            respuesta = await _servicioApi.comprar(movimineto);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NoContent();
            }
        }

        
    }
}
