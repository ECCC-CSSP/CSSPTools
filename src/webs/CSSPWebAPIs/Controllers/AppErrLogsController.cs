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
    [Route("api/{culture}/[controller]")]
    [ApiController]
    public class AppErrLogsController : ControllerBase
    {
        CSSPDBContext db { get; set; }
        public AppErrLogsController(CSSPDBContext db) 
        {
            this.db = db;
        }

        // GET: api/AppErrLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppErrLog>>> GetAppErrLogs()
        {
            return await db.AppErrLogs.ToListAsync();
        }

        // GET: api/AppErrLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppErrLog>> GetAppErrLog(int id)
        {
            var appErrLog = await db.AppErrLogs.FindAsync(id);

            if (appErrLog == null)
            {
                return NotFound();
            }

            return appErrLog;
        }

        // PUT: api/AppErrLogs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppErrLog(int id, AppErrLog appErrLog)
        {
            if (id != appErrLog.AppErrLogID)
            {
                return BadRequest();
            }

            db.Entry(appErrLog).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppErrLogExists(id))
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

        // POST: api/AppErrLogs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AppErrLog>> PostAppErrLog(AppErrLog appErrLog)
        {
            db.AppErrLogs.Add(appErrLog);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetAppErrLog", new { id = appErrLog.AppErrLogID }, appErrLog);
        }

        // DELETE: api/AppErrLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppErrLog>> DeleteAppErrLog(int id)
        {
            var appErrLog = await db.AppErrLogs.FindAsync(id);
            if (appErrLog == null)
            {
                return NotFound();
            }

            db.AppErrLogs.Remove(appErrLog);
            await db.SaveChangesAsync();

            return appErrLog;
        }

        private bool AppErrLogExists(int id)
        {
            return db.AppErrLogs.Any(e => e.AppErrLogID == id);
        }
    }
}
