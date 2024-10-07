using Prueba1_DOMAIN.Core.DTO;
using Prueba1_DOMAIN.Core.Entities;
using Prueba1_DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1_DOMAIN.Core.Services
{
    public class EventsService : IEventsService
    {
        private readonly IEventsRepository _eventsRepository;

        public EventsService(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public async Task<IEnumerable<EventsDTO>> getEventsDTO()
        {
            var events = await _eventsRepository.GetEvents();
            var eventsDTO = new List<EventsDTO>();
            foreach (var ev in events)
            {
                var eventDTO = new EventsDTO();
                eventDTO.Id = ev.Id;
                eventDTO.OrganizerId = ev.OrganizerId;
                eventDTO.EventName = ev.EventName;
                eventsDTO.Add(eventDTO);
            }
            return eventsDTO;
        }

    }
}
  