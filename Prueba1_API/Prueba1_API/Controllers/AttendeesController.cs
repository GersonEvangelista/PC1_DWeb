using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba1_DOMAIN.Core.Entities;
using Prueba1_DOMAIN.Data;

namespace Prueba1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        private readonly EventManagementDbContext _context; //Instancia de la BBDD

        public AttendeesController(EventManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/Attendees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendees>>> GetAttendees()
        {
            return await _context.Attendees.ToListAsync(); //Retorna de la base de datos los Attendees en una Lista
        }

        // GET: api/Attendees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendees>> GetAttendees(int id)
        {
            var attendees = await _context.Attendees.FindAsync(id);

            if (attendees == null)
            {
                return NotFound();
            }
            return attendees; //Retorna el attendees correspondiente en formato JSON
        }
        

        // POST: api/Attendees
        [HttpPost]
        public async Task<ActionResult<Attendees>> PostAttendees([FromBody]Attendees attendees)
        {
            _context.Attendees.Add(attendees);
            var result = await _context.SaveChangesAsync(); //Guardar cambios en la BBDD
            return Ok(result);
        }

        /* OTRA FORMA (Con retorno de entero)
        [HttpPost]
        public async Task<int> PostAttendees([FromBody]Attendees attendees)
        {
            _context.Attendees.Add(attendees);
            var result = await _context.SaveChangesAsync(); //Guardar cambios en la BBDD
            return result;
        } 
        */


        // DELETE: api/Attendees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendees(int id)
        {
            var attendees = await _context.Attendees.FindAsync(id);
            if (attendees == null)
            {
                return NotFound();
            }

            _context.Attendees.Remove(attendees);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendeesExists(int id)
        {
            return _context.Attendees.Any(e => e.Id == id);
        }
    }
}
