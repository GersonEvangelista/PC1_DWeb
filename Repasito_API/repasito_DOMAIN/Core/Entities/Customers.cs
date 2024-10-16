using System;
using System.Collections.Generic;

namespace repasito_DOMAIN.Data;

public partial class Customers
{
    public int IdCustomer { get; set; }

    public string? LastNames { get; set; }

    public string? Names { get; set; }

    public string? Dni { get; set; }

    public string? Telf { get; set; }

    public string? District { get; set; }

    public string? Province { get; set; }

    public string? Department { get; set; }

    public virtual ICollection<Sale> Sale { get; set; } = new List<Sale>();
}
