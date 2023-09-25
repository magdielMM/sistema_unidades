using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace sistema_unidades.Models;

public partial class Unidad
{
    public int Id { get; set; }

    public string Placa { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public long Folio { get; set; }

    public int NSerie { get; set; }

    public int IdCliente { get; set; }

    public bool Status { get; set; }

    public int IdTipo { get; set; }

    public int IdPeriodo { get; set; }

    [DisplayName("Cliente")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;
    
    [DisplayName("Periodo")]
    public virtual Periodo IdPeriodoNavigation { get; set; } = null!;
    
    [DisplayName("Tipo")]
    public virtual Tipo IdTipoNavigation { get; set; } = null!;
}
