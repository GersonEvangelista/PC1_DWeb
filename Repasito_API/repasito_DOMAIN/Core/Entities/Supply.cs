using System;
using System.Collections.Generic;

namespace repasito_DOMAIN.Data;

public partial class Supply
{
    public int IdSupply { get; set; }

    public int? IdSupplier { get; set; }

    public int? IdProduct { get; set; }

    public double? UnitPrice { get; set; }

    public int? Quantity { get; set; }

    public double? Discount { get; set; }

    public DateTime? DateSupply { get; set; }

    public virtual Products? IdProductNavigation { get; set; }

    public virtual Suppliers? IdSupplierNavigation { get; set; }
}
