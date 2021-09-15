using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WedApi.Models;

namespace WedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class locationsController : ControllerBase
    {
        private readonly locationContext _context;

        public locationsController(locationContext context)
        {
            _context = context;
        }

        // GET: api/locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<location>>> Getlocations()
        {
            return await _context.locations.ToListAsync();
           
        }

        // GET: api/locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<location>> Getlocation(int id)
        {
            var location = await _context.locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        // PUT: api/locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlocation(int id, location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!locationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<location>> Postlocation(location location)
        {
            _context.locations.Add(location);
            await _context.SaveChangesAsync();
   
            //return CreatedAtAction("Getlocation", new { id = location.Id }, location);
            return CreatedAtAction(nameof(Getlocation), new {id = location.Id  }, location);
        }

        // DELETE: api/locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelocation(int id)
        {
            var location = await _context.locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.locations.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool locationExists(int id)
        {
            return _context.locations.Any(e => e.Id == id);
        }
    }
}
