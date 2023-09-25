using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace sistema_unidades.Models;

public partial class Tipo
{
    public int Id { get; set; }

    [DisplayName("Tipo")]
    public string Tipo1 { get; set; } = null!;

    public virtual ICollection<Unidad> Unidads { get; set; } = new List<Unidad>();
}
