namespace tarjetacredito.cliente.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public static implicit operator Cliente(int v)
        {
            throw new NotImplementedException();
        }
    }
}
