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
    public class EmailsController : ControllerBase
    {
        private readonly CSSPDB2Context _context;

        public EmailsController(CSSPDB2Context context)
        {
            _context = context;
        }

        // GET: api/Emails
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Emails>>> GetEmails()
        {
            return await _context.Emails.ToListAsync();
        }

        // GET: api/Emails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emails>> GetEmails(int id)
        {
            var emails = await _context.Emails.FindAsync(id);

            if (emails == null)
            {
                return NotFound();
            }

            return emails;
        }

        // PUT: api/Emails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmails(int id, Emails emails)
        {
            if (id != emails.EmailID)
            {
                return BadRequest();
            }

            _context.Entry(emails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailsExists(id))
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

        // POST: api/Emails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Emails>> PostEmails(Emails emails)
        {
            _context.Emails.Add(emails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmails", new { id = emails.EmailID }, emails);
        }

        // DELETE: api/Emails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Emails>> DeleteEmails(int id)
        {
            var emails = await _context.Emails.FindAsync(id);
            if (emails == null)
            {
                return NotFound();
            }

            _context.Emails.Remove(emails);
            await _context.SaveChangesAsync();

            return emails;
        }

        private bool EmailsExists(int id)
        {
            return _context.Emails.Any(e => e.EmailID == id);
        }
    }
}
