using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSSPWebAPIs.Models.Temp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.OData;

namespace CSSPWebAPIs.Controllers.Temp
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TelsController : ControllerBase
    {
        private readonly CSSPDB2Context _context;

        public TelsController(CSSPDB2Context context)
        {
            _context = context;
        }

        // GET: api/Tels
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Tels>>> GetTels()
        {
            return await _context.Tels.ToListAsync();
        }

        // GET: api/Tels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tels>> GetTels(int id)
        {
            var tels = await _context.Tels.FindAsync(id);

            if (tels == null)
            {
                return NotFound();
            }

            return tels;
        }

        // PUT: api/Tels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTels(int id, Tels tels)
        {
            if (id != tels.TelID)
            {
                return BadRequest();
            }

            _context.Entry(tels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelsExists(id))
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

        // POST: api/Tels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tels>> PostTels(Tels tels)
        {
            _context.Tels.Add(tels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTels", new { id = tels.TelID }, tels);
        }

        // DELETE: api/Tels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tels>> DeleteTels(int id)
        {
            var tels = await _context.Tels.FindAsync(id);
            if (tels == null)
            {
                return NotFound();
            }

            _context.Tels.Remove(tels);
            await _context.SaveChangesAsync();

            return tels;
        }

        private bool TelsExists(int id)
        {
            return _context.Tels.Any(e => e.TelID == id);
        }
    }
}
