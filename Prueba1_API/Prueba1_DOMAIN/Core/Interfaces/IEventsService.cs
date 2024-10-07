using Prueba1_DOMAIN.Core.DTO;

namespace Prueba1_DOMAIN.Core.Interfaces
{
    public interface IEventsService
    {
        Task<IEnumerable<EventsDTO>> getEventsDTO();
    }
}