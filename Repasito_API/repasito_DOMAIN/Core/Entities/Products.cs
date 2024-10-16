using System;
using System.Collections.Generic;

namespace repasito_DOMAIN.Data;

public partial class Products
{
    public int IdProduct { get; set; }

    public string? ProductName { get; set; }

    public string? DescriptionNotes { get; set; }

    public int? IdCategory { get; set; }

    public virtual Categories? IdCategoryNavigation { get; set; }

    public virtual ICollection<Sale> Sale { get; set; } = new List<Sale>();

    public virtual ICollection<Supply> Supply { get; set; } = new List<Supply>();
}
