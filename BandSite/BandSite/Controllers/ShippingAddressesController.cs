using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BandSite.Data;
using BandSite.Models;

namespace BandSite.Controllers
{
    public class ShippingAddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShippingAddressesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ShippingAddresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShippingAddress.ToListAsync());
        }

        // GET: ShippingAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingAddress = await _context.ShippingAddress
                .SingleOrDefaultAsync(m => m.ShippingAddressId == id);
            if (shippingAddress == null)
            {
                return NotFound();
            }

            return View(shippingAddress);
        }

        // GET: ShippingAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShippingAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShippingAddressId,Street,City,State,ZipCode,Phone")] ShippingAddress shippingAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shippingAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(shippingAddress);
        }

        // GET: ShippingAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingAddress = await _context.ShippingAddress.SingleOrDefaultAsync(m => m.ShippingAddressId == id);
            if (shippingAddress == null)
            {
                return NotFound();
            }
            return View(shippingAddress);
        }

        // POST: ShippingAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShippingAddressId,Street,City,State,ZipCode,Phone")] ShippingAddress shippingAddress)
        {
            if (id != shippingAddress.ShippingAddressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shippingAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippingAddressExists(shippingAddress.ShippingAddressId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(shippingAddress);
        }

        // GET: ShippingAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingAddress = await _context.ShippingAddress
                .SingleOrDefaultAsync(m => m.ShippingAddressId == id);
            if (shippingAddress == null)
            {
                return NotFound();
            }

            return View(shippingAddress);
        }

        // POST: ShippingAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shippingAddress = await _context.ShippingAddress.SingleOrDefaultAsync(m => m.ShippingAddressId == id);
            _context.ShippingAddress.Remove(shippingAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ShippingAddressExists(int id)
        {
            return _context.ShippingAddress.Any(e => e.ShippingAddressId == id);
        }
    }
}
