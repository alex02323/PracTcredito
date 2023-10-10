namespace tarjetacredito.cliente.Models
{
    public class Tarjeta
    {
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public string Nombre { get; set; } = null!;

        public string NTarjeta { get; set; } = null!;

        public string FVencimiento { get; set; } = null!;

        public bool Activa { get; set; }

        public decimal Limite { get; set; }

        public decimal Disponible { get; set; }

        public decimal PContado { get; set; }

        public decimal PMinimo { get; set; }
    }
}
