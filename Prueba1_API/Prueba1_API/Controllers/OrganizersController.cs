using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba1_DOMAIN.Core.Entities;
using Prueba1_DOMAIN.Data;

namespace Prueba1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizersController : ControllerBase
    {
        private readonly EventManagementDbContext _context;

        public OrganizersController(EventManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/Organizers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organizers>>> GetOrganizers()
        {
            return await _context.Organizers.ToListAsync();
        }

        // POST: api/Organizers
        [HttpPost]
        public async Task<ActionResult<Organizers>> PostOrganizers([FromBody] Organizers organizers)
        {
            _context.Organizers.Add(organizers);
            int organizerId = await _context.SaveChangesAsync();
            return Ok(organizerId);
        }

        // DELETE: api/Organizers/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizers(int id)
        {
            var organizers = await _context.Organizers.FindAsync(id);
            if (organizers == null)
            {
                return NotFound();
            }

            _context.Organizers.Remove(organizers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
    


}
