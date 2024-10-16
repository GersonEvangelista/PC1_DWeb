using System;
using System.Collections.Generic;

namespace repasito_DOMAIN.Data;

public partial class Categories
{
    public int IdCategory { get; set; }

    public string? CategoryName { get; set; }

    public string? DescriptionNotes { get; set; }

    public virtual ICollection<Products> Products { get; set; } = new List<Products>();
}
