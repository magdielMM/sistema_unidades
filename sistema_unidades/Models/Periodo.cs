using System;
using System.Collections.Generic;

namespace sistema_unidades.Models;

public partial class Periodo
{
    public int Id { get; set; }

    public string Mes { get; set; } = null!;

    public virtual ICollection<Unidad> Unidads { get; set; } = new List<Unidad>();
}
