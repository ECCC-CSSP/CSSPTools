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
    public class MikeBoundaryConditionsController : ControllerBase
    {
        private readonly CSSPDBContext _context;

        public MikeBoundaryConditionsController(CSSPDBContext context)
        {
            _context = context;
        }

        // GET: api/MikeBoundaryConditions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MikeBoundaryCondition>>> GetMikeBoundaryConditions()
        {
            return await _context.MikeBoundaryConditions.ToListAsync();
        }

        // GET: api/MikeBoundaryConditions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MikeBoundaryCondition>> GetMikeBoundaryCondition(int id)
        {
            var mikeBoundaryCondition = await _context.MikeBoundaryConditions.FindAsync(id);

            if (mikeBoundaryCondition == null)
            {
                return NotFound();
            }

            return mikeBoundaryCondition;
        }

        // PUT: api/MikeBoundaryConditions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMikeBoundaryCondition(int id, MikeBoundaryCondition mikeBoundaryCondition)
        {
            if (id != mikeBoundaryCondition.MikeBoundaryConditionID)
            {
                return BadRequest();
            }

            _context.Entry(mikeBoundaryCondition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MikeBoundaryConditionExists(id))
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

        // POST: api/MikeBoundaryConditions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MikeBoundaryCondition>> PostMikeBoundaryCondition(MikeBoundaryCondition mikeBoundaryCondition)
        {
            _context.MikeBoundaryConditions.Add(mikeBoundaryCondition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMikeBoundaryCondition", new { id = mikeBoundaryCondition.MikeBoundaryConditionID }, mikeBoundaryCondition);
        }

        // DELETE: api/MikeBoundaryConditions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MikeBoundaryCondition>> DeleteMikeBoundaryCondition(int id)
        {
            var mikeBoundaryCondition = await _context.MikeBoundaryConditions.FindAsync(id);
            if (mikeBoundaryCondition == null)
            {
                return NotFound();
            }

            _context.MikeBoundaryConditions.Remove(mikeBoundaryCondition);
            await _context.SaveChangesAsync();

            return mikeBoundaryCondition;
        }

        private bool MikeBoundaryConditionExists(int id)
        {
            return _context.MikeBoundaryConditions.Any(e => e.MikeBoundaryConditionID == id);
        }
    }
}
