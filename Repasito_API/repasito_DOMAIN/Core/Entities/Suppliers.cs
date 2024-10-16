using System;
using System.Collections.Generic;

namespace repasito_DOMAIN.Data;

public partial class Suppliers
{
    public int IdSupplier { get; set; }

    public string? NameCompany { get; set; }

    public string? Telf { get; set; }

    public string? City { get; set; }

    public string? AddressLocation { get; set; }

    public virtual ICollection<Supply> Supply { get; set; } = new List<Supply>();
}
