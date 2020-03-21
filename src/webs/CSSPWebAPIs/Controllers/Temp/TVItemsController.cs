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
    public class TVItemsController : ControllerBase
    {
        private readonly CSSPDB2Context _context;

        public TVItemsController(CSSPDB2Context context)
        {
            _context = context;
        }

        // GET: api/TVItems
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<TVItems>>> GetTVItems()
        {
            return await _context.TVItems.ToListAsync();
        }

        // GET: api/TVItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TVItems>> GetTVItems(int id)
        {
            var tVItems = await _context.TVItems.FindAsync(id);

            if (tVItems == null)
            {
                return NotFound();
            }

            return tVItems;
        }

        // PUT: api/TVItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTVItems(int id, TVItems tVItems)
        {
            if (id != tVItems.TVItemID)
            {
                return BadRequest();
            }

            _context.Entry(tVItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TVItemsExists(id))
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

        // POST: api/TVItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TVItems>> PostTVItems(TVItems tVItems)
        {
            _context.TVItems.Add(tVItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTVItems", new { id = tVItems.TVItemID }, tVItems);
        }

        // DELETE: api/TVItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TVItems>> DeleteTVItems(int id)
        {
            var tVItems = await _context.TVItems.FindAsync(id);
            if (tVItems == null)
            {
                return NotFound();
            }

            _context.TVItems.Remove(tVItems);
            await _context.SaveChangesAsync();

            return tVItems;
        }

        private bool TVItemsExists(int id)
        {
            return _context.TVItems.Any(e => e.TVItemID == id);
        }
    }
}
