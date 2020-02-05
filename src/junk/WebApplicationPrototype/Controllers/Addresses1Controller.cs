using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationPrototype.Models;

namespace WebApplicationPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Addresses1Controller : ControllerBase
    {
        private readonly CSSPDBContext _context;

        public Addresses1Controller(CSSPDBContext context)
        {
            _context = context;
        }

        // GET: api/Addresses1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Addresses>>> GetAddresses()
        {
            string a = User.Identity.Name;

            return await _context.Addresses.Take(5).ToListAsync();
        }

        // GET: api/Addresses1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Addresses>> GetAddresses(int id)
        {
            var addresses = await _context.Addresses.FindAsync(id);

            if (addresses == null)
            {
                return NotFound();
            }

            return addresses;
        }

        // PUT: api/Addresses1/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddresses(int id, Addresses addresses)
        {
            if (id != addresses.AddressID)
            {
                return BadRequest();
            }

            _context.Entry(addresses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressesExists(id))
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

        // POST: api/Addresses1
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Addresses>> PostAddresses(Addresses addresses)
        {
            _context.Addresses.Add(addresses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddresses", new { id = addresses.AddressID }, addresses);
        }

        // DELETE: api/Addresses1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Addresses>> DeleteAddresses(int id)
        {
            var addresses = await _context.Addresses.FindAsync(id);
            if (addresses == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(addresses);
            await _context.SaveChangesAsync();

            return addresses;
        }

        private bool AddressesExists(int id)
        {
            return _context.Addresses.Any(e => e.AddressID == id);
        }
    }
}
