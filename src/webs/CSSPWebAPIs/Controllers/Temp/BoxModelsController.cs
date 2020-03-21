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
    public class BoxModelsController : ControllerBase
    {
        private readonly CSSPDB2Context _context;

        public BoxModelsController(CSSPDB2Context context)
        {
            _context = context;
        }

        // GET: api/BoxModels
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<BoxModels>>> GetBoxModels()
        {
            return await _context.BoxModels.ToListAsync();
        }

        // GET: api/BoxModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoxModels>> GetBoxModels(int id)
        {
            var boxModels = await _context.BoxModels.FindAsync(id);

            if (boxModels == null)
            {
                return NotFound();
            }

            return boxModels;
        }

        // PUT: api/BoxModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoxModels(int id, BoxModels boxModels)
        {
            if (id != boxModels.BoxModelID)
            {
                return BadRequest();
            }

            _context.Entry(boxModels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoxModelsExists(id))
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

        // POST: api/BoxModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BoxModels>> PostBoxModels(BoxModels boxModels)
        {
            _context.BoxModels.Add(boxModels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoxModels", new { id = boxModels.BoxModelID }, boxModels);
        }

        // DELETE: api/BoxModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoxModels>> DeleteBoxModels(int id)
        {
            var boxModels = await _context.BoxModels.FindAsync(id);
            if (boxModels == null)
            {
                return NotFound();
            }

            _context.BoxModels.Remove(boxModels);
            await _context.SaveChangesAsync();

            return boxModels;
        }

        private bool BoxModelsExists(int id)
        {
            return _context.BoxModels.Any(e => e.BoxModelID == id);
        }
    }
}
