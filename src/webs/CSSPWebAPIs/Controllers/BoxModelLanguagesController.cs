using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSSPModels;

namespace CSSPWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxModelLanguagesController : ControllerBase
    {
        private readonly CSSPDBContext _context;

        public BoxModelLanguagesController(CSSPDBContext context)
        {
            _context = context;
        }

        // GET: api/BoxModelLanguages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoxModelLanguage>>> GetBoxModelLanguages()
        {
            return await _context.BoxModelLanguages.ToListAsync();
        }

        // GET: api/BoxModelLanguages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoxModelLanguage>> GetBoxModelLanguage(int id)
        {
            var boxModelLanguage = await _context.BoxModelLanguages.FindAsync(id);

            if (boxModelLanguage == null)
            {
                return NotFound();
            }

            return boxModelLanguage;
        }

        // PUT: api/BoxModelLanguages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoxModelLanguage(int id, BoxModelLanguage boxModelLanguage)
        {
            if (id != boxModelLanguage.BoxModelLanguageID)
            {
                return BadRequest();
            }

            _context.Entry(boxModelLanguage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoxModelLanguageExists(id))
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
        public async Task<ActionResult<BoxModelLanguage>> PostBoxModelLanguage(BoxModelLanguage boxModelLanguage)
        {
            _context.BoxModelLanguages.Add(boxModelLanguage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoxModelLanguage", new { id = boxModelLanguage.BoxModelLanguageID }, boxModelLanguage);
        }

        // DELETE: api/BoxModelLanguages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoxModelLanguage>> DeleteBoxModelLanguage(int id)
        {
            var boxModelLanguage = await _context.BoxModelLanguages.FindAsync(id);
            if (boxModelLanguage == null)
            {
                return NotFound();
            }

            _context.BoxModelLanguages.Remove(boxModelLanguage);
            await _context.SaveChangesAsync();

            return boxModelLanguage;
        }

        private bool BoxModelLanguageExists(int id)
        {
            return _context.BoxModelLanguages.Any(e => e.BoxModelLanguageID == id);
        }
    }
}
