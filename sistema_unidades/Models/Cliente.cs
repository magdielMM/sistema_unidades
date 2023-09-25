using System;
using System.Collections.Generic;

namespace sistema_unidades.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public long? Telefono { get; set; }

    public virtual ICollection<Unidad> Unidads { get; set; } = new List<Unidad>();
}
