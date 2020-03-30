using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSSPModels;
using Microsoft.AspNet.OData;

namespace CSSPWebAPIs.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    [EnableQuery]
    public class BoxModelsController : ControllerBase
    {
        CSSPDBContext db { get; set; }

        public BoxModelsController(CSSPDBContext db) 
        {
            this.db = db;
        }

        // GET: api/BoxModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoxModel>>> GetBoxModels()
        {
            return await db.BoxModels.ToListAsync();
        }

        // GET: api/BoxModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoxModel>> GetBoxModel(int id)
        {
            var boxModel = await db.BoxModels.FindAsync(id);

            if (boxModel == null)
            {
                return NotFound();
            }

            return boxModel;
        }

        // PUT: api/BoxModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoxModel(int id, BoxModel boxModel)
        {
            if (id != boxModel.BoxModelID)
            {
                return BadRequest();
            }

            db.Entry(boxModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoxModelExists(id))
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
        public async Task<ActionResult<BoxModel>> PostBoxModel([FromBody]BoxModel boxModel)
        {
            try
            {
                db.BoxModels.Add(boxModel);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return CreatedAtAction("GetBoxModel", new { id = boxModel.BoxModelID }, boxModel);
        }

        // DELETE: api/BoxModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoxModel>> DeleteBoxModel(int id)
        {
            var boxModel = await db.BoxModels.FindAsync(id);
            if (boxModel == null)
            {
                return NotFound();
            }

            db.BoxModels.Remove(boxModel);
            await db.SaveChangesAsync();

            return boxModel;
        }

        private bool BoxModelExists(int id)
        {
            return db.BoxModels.Any(e => e.BoxModelID == id);
        }
    }
}
