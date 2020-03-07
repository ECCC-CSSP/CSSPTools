using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVCAPI.Models;

namespace WebMVCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppErrLogsController : ControllerBase
    {
        private readonly CSSPDB2Context _context;

        public AppErrLogsController(CSSPDB2Context context)
        {
            _context = context;
        }

        // GET: api/AppErrLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppErrLogs>>> GetAppErrLogs()
        {
            return await _context.AppErrLogs.ToListAsync();
        }

        // GET: api/AppErrLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppErrLogs>> GetAppErrLogs(int id)
        {
            var appErrLogs = await _context.AppErrLogs.FindAsync(id);

            if (appErrLogs == null)
            {
                return NotFound();
            }

            return appErrLogs;
        }

        // PUT: api/AppErrLogs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppErrLogs(int id, AppErrLogs appErrLogs)
        {
            if (id != appErrLogs.AppErrLogID)
            {
                return BadRequest();
            }

            _context.Entry(appErrLogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppErrLogsExists(id))
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
        public async Task<ActionResult<AppErrLogs>> PostAppErrLogs(AppErrLogs appErrLogs)
        {
            _context.AppErrLogs.Add(appErrLogs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppErrLogs", new { id = appErrLogs.AppErrLogID }, appErrLogs);
        }

        // DELETE: api/AppErrLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppErrLogs>> DeleteAppErrLogs(int id)
        {
            var appErrLogs = await _context.AppErrLogs.FindAsync(id);
            if (appErrLogs == null)
            {
                return NotFound();
            }

            _context.AppErrLogs.Remove(appErrLogs);
            await _context.SaveChangesAsync();

            return appErrLogs;
        }

        private bool AppErrLogsExists(int id)
        {
            return _context.AppErrLogs.Any(e => e.AppErrLogID == id);
        }
    }
}
