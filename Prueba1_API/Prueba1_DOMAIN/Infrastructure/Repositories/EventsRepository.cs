using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Prueba1_DOMAIN.Core.Entities;
using Prueba1_DOMAIN.Core.Interfaces;
using Prueba1_DOMAIN.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1_DOMAIN.Infrastructure.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly EventManagementDbContext _dbContex;
        public EventsRepository(EventManagementDbContext dbContex)
        {
            _dbContex = dbContex;
        }

        public async Task<IEnumerable<Events>> GetEvents()
        {
            var events = await _dbContex.Events.ToListAsync();
            return events;
        }



    }
}
