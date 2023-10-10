namespace tarjetacredito.cliente.Models
{
    public class Movimientos
    {
        public int Id { get; set; }

        public int IdTarjeta { get; set; }

        public DateTime FTransaccion { get; set; }

        public string Descripcion { get; set; } = null!;

        public decimal Monto { get; set; }
    }
}
