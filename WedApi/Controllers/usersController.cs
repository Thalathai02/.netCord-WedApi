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
    public class usersController : ControllerBase
    {
        private readonly locationContext _context;

        public usersController(locationContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<user>>> Getusers()
        {
            return await _context.users.ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<user>> Getuser(int id)
        {
            //var user_id = await _context.users.FindAsync(id);


            var result = from user in _context.users
                         join location in _context.locations on user.IdUsers equals location.User into locations
                         from m in locations.DefaultIfEmpty()
                         orderby user.IdUsers where user.IdUsers == id 
                         select new
                         {
                             IdUsers = user.IdUsers,
                             UUID = user.UUID,
                             locations = m
                         };
            //return Ok(result);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }


        // PUT: api/users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putuser(int id, user user)
        {
            if (id != user.IdUsers)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(id))
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

        // POST: api/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<user>> Postuser(user user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("Getuser", new { id = user.Id }, user);
            return CreatedAtAction(nameof(Getuser), new { id = user.IdUsers }, user);
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteuser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool userExists(int id)
        {
            return _context.users.Any(e => e.IdUsers == id);
        }
    }
}
