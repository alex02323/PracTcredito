using System;
using System.Collections.Generic;

namespace tarjetacredito.Models;

public partial class Movimiento
{
    public int Id { get; set; }

    public int IdTarjeta { get; set; }

    public DateTime FTransaccion { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Monto { get; set; }

    public virtual Tarjeta IdTarjetaNavigation { get; set; } = null!;
}
