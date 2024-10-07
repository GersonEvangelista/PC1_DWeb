using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1_DOMAIN.Core.DTO
{
    public class EventsDTO
    {
        public int Id { get; set; }

        public int? OrganizerId { get; set; }

        public string EventName { get; set; } = null!;
    }


}
