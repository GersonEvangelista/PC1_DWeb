using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repasito_DOMAIN.Core.DTO
{
    public class ProductsDTO
    {
        public int IdProduct { get; set; }

        public string? ProductName { get; set; }

        public int? IdCategory { get; set; }
    }
}
