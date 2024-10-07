using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba1_DOMAIN.Core.DTO;
using Prueba1_DOMAIN.Core.Interfaces;
using Prueba1_DOMAIN.Data;

namespace Prueba1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsDTOController : ControllerBase
    {
        private readonly IEventsService _eventService;
        public EventsDTOController(IEventsService eventsService) {
            _eventService = eventsService;
        }

        [HttpGet]
        public async Task<ActionResult> getEventsDTO()
        {
            var events = await _eventService.getEventsDTO();
            return Ok(events);
        }

    }
}
