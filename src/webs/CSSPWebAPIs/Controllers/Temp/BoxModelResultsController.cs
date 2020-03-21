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
    public class BoxModelResultsController : ControllerBase
    {
        private readonly CSSPDB2Context _context;

        public BoxModelResultsController(CSSPDB2Context context)
        {
            _context = context;
        }

        // GET: api/BoxModelResults
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<BoxModelResults>>> GetBoxModelResults()
        {
            return await _context.BoxModelResults.ToListAsync();
        }

        // GET: api/BoxModelResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoxModelResults>> GetBoxModelResults(int id)
        {
            var boxModelResults = await _context.BoxModelResults.FindAsync(id);

            if (boxModelResults == null)
            {
                return NotFound();
            }

            return boxModelResults;
        }

        // PUT: api/BoxModelResults/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoxModelResults(int id, BoxModelResults boxModelResults)
        {
            if (id != boxModelResults.BoxModelResultID)
            {
                return BadRequest();
            }

            _context.Entry(boxModelResults).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoxModelResultsExists(id))
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

        // POST: api/BoxModelResults
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BoxModelResults>> PostBoxModelResults(BoxModelResults boxModelResults)
        {
            _context.BoxModelResults.Add(boxModelResults);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoxModelResults", new { id = boxModelResults.BoxModelResultID }, boxModelResults);
        }

        // DELETE: api/BoxModelResults/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoxModelResults>> DeleteBoxModelResults(int id)
        {
            var boxModelResults = await _context.BoxModelResults.FindAsync(id);
            if (boxModelResults == null)
            {
                return NotFound();
            }

            _context.BoxModelResults.Remove(boxModelResults);
            await _context.SaveChangesAsync();

            return boxModelResults;
        }

        private bool BoxModelResultsExists(int id)
        {
            return _context.BoxModelResults.Any(e => e.BoxModelResultID == id);
        }
    }
}
