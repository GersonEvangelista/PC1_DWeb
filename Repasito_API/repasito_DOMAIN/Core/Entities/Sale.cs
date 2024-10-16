using System;
using System.Collections.Generic;

namespace repasito_DOMAIN.Data;

public partial class Sale
{
    public int IdSale { get; set; }

    public DateTime? DateSale { get; set; }

    public int? IdProduct { get; set; }

    public int? IdCustomer { get; set; }

    public double? UnitPrice { get; set; }

    public int? Quantity { get; set; }

    public double? Discount { get; set; }

    public string? Notes { get; set; }

    public virtual Customers? IdCustomerNavigation { get; set; }

    public virtual Products? IdProductNavigation { get; set; }
}
