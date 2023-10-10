using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class TarjetaDTO
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
