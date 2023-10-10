using System.Threading.Tasks;
using tarjetacredito.cliente.Models;

namespace tarjetacredito.cliente.Servicios
{
    public interface Itarjeta
    {
        Task<Cliente> Client(int idCliente);

        Task<List<Tarjeta>> ListaTarjetas(int idCliente);
        Task<List<Movimientos>> MovimientosTar(int idCliente);
        Task<bool> pagar(Movimientos movimiento);
        Task<bool> comprar(Movimientos movimiento);
    }
}
