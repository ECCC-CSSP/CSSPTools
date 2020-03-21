using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSSPWebAPIs.Models.Temp;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;

namespace CSSPWebAPIs.Controllers.Temp
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BoxModelLanguagesController : ControllerBase
    {
        private readonly CSSPDB2Context _context;

        public BoxModelLanguagesController(CSSPDB2Context context)
        {
            _context = context;
        }

        // GET: api/BoxModelLanguages
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<BoxModelLanguages>>> GetBoxModelLanguages()
        {
            return await _context.BoxModelLanguages.ToListAsync();
        }

        // GET: api/BoxModelLanguages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoxModelLanguages>> GetBoxModelLanguages(int id)
        {
            var boxModelLanguages = await _context.BoxModelLanguages.FindAsync(id);

            if (boxModelLanguages == null)
            {
                return NotFound();
            }

            return boxModelLanguages;
        }

        // PUT: api/BoxModelLanguages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoxModelLanguages(int id, BoxModelLanguages boxModelLanguages)
        {
            if (id != boxModelLanguages.BoxModelLanguageID)
            {
                return BadRequest();
            }

            _context.Entry(boxModelLanguages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoxModelLanguagesExists(id))
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

        // POST: api/BoxModelLanguages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BoxModelLanguages>> PostBoxModelLanguages(BoxModelLanguages boxModelLanguages)
        {
            _context.BoxModelLanguages.Add(boxModelLanguages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoxModelLanguages", new { id = boxModelLanguages.BoxModelLanguageID }, boxModelLanguages);
        }

        // DELETE: api/BoxModelLanguages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoxModelLanguages>> DeleteBoxModelLanguages(int id)
        {
            var boxModelLanguages = await _context.BoxModelLanguages.FindAsync(id);
            if (boxModelLanguages == null)
            {
                return NotFound();
            }

            _context.BoxModelLanguages.Remove(boxModelLanguages);
            await _context.SaveChangesAsync();

            return boxModelLanguages;
        }

        private bool BoxModelLanguagesExists(int id)
        {
            return _context.BoxModelLanguages.Any(e => e.BoxModelLanguageID == id);
        }
    }
}
