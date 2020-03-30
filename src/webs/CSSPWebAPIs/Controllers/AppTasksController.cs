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
    public class AppTasksController : ControllerBase
    {
        private readonly CSSPDBContext _context;

        public AppTasksController(CSSPDBContext context)
        {
            _context = context;
        }

        // GET: api/AppTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppTask>>> GetAppTasks()
        {
            return await _context.AppTasks.ToListAsync();
        }

        // GET: api/AppTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppTask>> GetAppTask(int id)
        {
            var appTask = await _context.AppTasks.FindAsync(id);

            if (appTask == null)
            {
                return NotFound();
            }

            return appTask;
        }

        // PUT: api/AppTasks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppTask(int id, AppTask appTask)
        {
            if (id != appTask.AppTaskID)
            {
                return BadRequest();
            }

            _context.Entry(appTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppTaskExists(id))
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

        // POST: api/AppTasks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AppTask>> PostAppTask(AppTask appTask)
        {
            _context.AppTasks.Add(appTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppTask", new { id = appTask.AppTaskID }, appTask);
        }

        // DELETE: api/AppTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppTask>> DeleteAppTask(int id)
        {
            var appTask = await _context.AppTasks.FindAsync(id);
            if (appTask == null)
            {
                return NotFound();
            }

            _context.AppTasks.Remove(appTask);
            await _context.SaveChangesAsync();

            return appTask;
        }

        private bool AppTaskExists(int id)
        {
            return _context.AppTasks.Any(e => e.AppTaskID == id);
        }
    }
}
