using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationPrototype.Models;

namespace WebApplicationPrototype.Controllers
{
    public class AddressesController : Controller
    {
        private readonly CSSPDBContext _context;

        public AddressesController(CSSPDBContext context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            var cSSPDBContext = _context.Addresses.Include(a => a.AddressTVItem).Include(a => a.CountryTVItem).Include(a => a.MunicipalityTVItem).Include(a => a.ProvinceTVItem);
            return View(await cSSPDBContext.Take(5).ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addresses = await _context.Addresses
                .Include(a => a.AddressTVItem)
                .Include(a => a.CountryTVItem)
                .Include(a => a.MunicipalityTVItem)
                .Include(a => a.ProvinceTVItem)
                .FirstOrDefaultAsync(m => m.AddressID == id);
            if (addresses == null)
            {
                return NotFound();
            }

            return View(addresses);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            ViewData["AddressTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath");
            ViewData["CountryTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath");
            ViewData["MunicipalityTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath");
            ViewData["ProvinceTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressID,AddressTVItemID,AddressType,CountryTVItemID,ProvinceTVItemID,MunicipalityTVItemID,StreetName,StreetNumber,StreetType,PostalCode,GoogleAddressText,LastUpdateDate_UTC,LastUpdateContactTVItemID")] Addresses addresses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addresses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath", addresses.AddressTVItemID);
            ViewData["CountryTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath", addresses.CountryTVItemID);
            ViewData["MunicipalityTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath", addresses.MunicipalityTVItemID);
            ViewData["ProvinceTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath", addresses.ProvinceTVItemID);
            return View(addresses);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addresses = await _context.Addresses.FindAsync(id);
            if (addresses == null)
            {
                return NotFound();
            }
            ViewData["AddressTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath", addresses.AddressTVItemID);
            ViewData["CountryTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath", addresses.CountryTVItemID);
            ViewData["MunicipalityTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath", addresses.MunicipalityTVItemID);
            ViewData["ProvinceTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath", addresses.ProvinceTVItemID);
            return View(addresses);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressID,AddressTVItemID,AddressType,CountryTVItemID,ProvinceTVItemID,MunicipalityTVItemID,StreetName,StreetNumber,StreetType,PostalCode,GoogleAddressText,LastUpdateDate_UTC,LastUpdateContactTVItemID")] Addresses addresses)
        {
            if (id != addresses.AddressID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addresses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressesExists(addresses.AddressID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath", addresses.AddressTVItemID);
            ViewData["CountryTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath", addresses.CountryTVItemID);
            ViewData["MunicipalityTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath", addresses.MunicipalityTVItemID);
            ViewData["ProvinceTVItemID"] = new SelectList(_context.TVItems, "TVItemID", "TVPath", addresses.ProvinceTVItemID);
            return View(addresses);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addresses = await _context.Addresses
                .Include(a => a.AddressTVItem)
                .Include(a => a.CountryTVItem)
                .Include(a => a.MunicipalityTVItem)
                .Include(a => a.ProvinceTVItem)
                .FirstOrDefaultAsync(m => m.AddressID == id);
            if (addresses == null)
            {
                return NotFound();
            }

            return View(addresses);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addresses = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(addresses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressesExists(int id)
        {
            return _context.Addresses.Any(e => e.AddressID == id);
        }
    }
}
