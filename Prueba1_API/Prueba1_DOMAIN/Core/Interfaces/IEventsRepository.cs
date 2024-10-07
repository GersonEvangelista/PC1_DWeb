using Prueba1_DOMAIN.Core.Entities;

namespace Prueba1_DOMAIN.Core.Interfaces
{
    public interface IEventsRepository
    {
        Task<IEnumerable<Events>> GetEvents();
    }
}