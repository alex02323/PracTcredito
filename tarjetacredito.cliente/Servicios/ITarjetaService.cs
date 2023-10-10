using Newtonsoft.Json;
using System.Net.Http.Headers;
using System;
using System.Text;
using tarjetacredito.cliente.Models;
using Shared;

namespace tarjetacredito.cliente.Servicios
{
    public class ITarjetaService : Itarjeta
    {
        public ITarjetaService()
        {
            
        }

        private string urlAppi = "http://localhost:5258/api/tc/";
        public async Task<Cliente> Client(int idCliente)
        {
            var _http = new HttpClient();

            var result = await _http.GetFromJsonAsync<ResponseAPI<Cliente>>(urlAppi + $"Cliente/{idCliente}");
            return result!.Valor!;
        }

        public async Task<List<Tarjeta>> ListaTarjetas(int idCliente)
        {
            var _http = new HttpClient();

            var result = await _http.GetFromJsonAsync<ResponseAPI<List<Tarjeta>>>(urlAppi + $"Tarjetas/{idCliente}");
            return result!.Valor!;
        }

        public async Task<List<Movimientos>> MovimientosTar(int idTarjeta)
        {
            var _http = new HttpClient();

            var result = await _http.GetFromJsonAsync<ResponseAPI<List<Movimientos>>>(urlAppi + $"Movimientos/{idTarjeta}");
            return result!.Valor!;
        }

        public async Task<bool> pagar(Movimientos movimiento)
        {
            bool respuesta = false;
            var _http = new HttpClient();
            movimiento.Descripcion = "Pago-" + movimiento.Descripcion;
            var content = new StringContent(JsonConvert.SerializeObject(movimiento), Encoding.UTF8, "application/json");
            var result = await _http.PostAsync(urlAppi + $"Pago/", content);

            if (result.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> comprar(Movimientos movimiento)
        {
            bool respuesta = false;
            var _http = new HttpClient();
            movimiento.Descripcion = "Compra-" + movimiento.Descripcion;
            var content = new StringContent(JsonConvert.SerializeObject(movimiento), Encoding.UTF8, "application/json");
            var result = await _http.PostAsync(urlAppi + $"Compra/", content);

            if (result.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
