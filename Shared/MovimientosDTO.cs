using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class MovimientosDTO
    {
        public int Id { get; set; }

        public int IdTarjeta { get; set; }

        public DateTime FTransaccion { get; set; }

        public string Descripcion { get; set; } = null!;

        public decimal Monto { get; set; }
    }
}
