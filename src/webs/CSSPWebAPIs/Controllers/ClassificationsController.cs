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
    public class ClassificationsController : ControllerBase
    {
        private readonly CSSPDBContext _context;

        public ClassificationsController(CSSPDBContext context)
        {
            _context = context;
        }

        // GET: api/Classifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classification>>> GetClassifications()
        {
            return await _context.Classifications.ToListAsync();
        }

        // GET: api/Classifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classification>> GetClassification(int id)
        {
            var classification = await _context.Classifications.FindAsync(id);

            if (classification == null)
            {
                return NotFound();
            }

            return classification;
        }

        // PUT: api/Classifications/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassification(int id, Classification classification)
        {
            if (id != classification.ClassificationID)
            {
                return BadRequest();
            }

            _context.Entry(classification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassificationExists(id))
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

        // POST: api/Classifications
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Classification>> PostClassification(Classification classification)
        {
            _context.Classifications.Add(classification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassification", new { id = classification.ClassificationID }, classification);
        }

        // DELETE: api/Classifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Classification>> DeleteClassification(int id)
        {
            var classification = await _context.Classifications.FindAsync(id);
            if (classification == null)
            {
                return NotFound();
            }

            _context.Classifications.Remove(classification);
            await _context.SaveChangesAsync();

            return classification;
        }

        private bool ClassificationExists(int id)
        {
            return _context.Classifications.Any(e => e.ClassificationID == id);
        }
    }
}
