using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BandSite.Data;
using BandSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace BandSite.Controllers
{
    public class ForaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ForaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager )
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Fora
        public async Task<IActionResult> Index()
        {
            return View(await _context.Forum.ToListAsync());
        }

        // GET: Fora/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = await _context.Forum
                .SingleOrDefaultAsync(m => m.ForumId == id);
            if (forum == null)
            {
                return NotFound();
            }

            return View(forum);
        }

        // GET: Fora/Create
        public async Task<IActionResult> Create()
        {
            var forum = new Forum();
            var user = await GetCurrentUserAsync();
       
            
            return View(forum);
        }

        // POST: Fora/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Forum forum)
        {
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                forum.user = user;
                _context.Add(forum);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = forum.ForumId });
            }
            ViewData["ForumId"] = new SelectList(_context.Forum, "ForumId", "ForumId", forum.ForumId);
          
            return View(forum);
        }

        // GET: Fora/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = await _context.Forum.SingleOrDefaultAsync(m => m.ForumId == id);
            if (forum == null)
            {
                return NotFound();
            }
            return View(forum);
        }

        // POST: Fora/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ForumId,ForumTitle,ForumMessage,DateCreated")] Forum forum)
        {
            if (id != forum.ForumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumExists(forum.ForumId))
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
            return View(forum);
        }

        // GET: Fora/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = await _context.Forum
                .SingleOrDefaultAsync(m => m.ForumId == id);
            if (forum == null)
            {
                return NotFound();
            }

            return View(forum);
        }

        // POST: Fora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forum = await _context.Forum.SingleOrDefaultAsync(m => m.ForumId == id);
            _context.Forum.Remove(forum);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ForumExists(int id)
        {
            return _context.Forum.Any(e => e.ForumId == id);
        }
    }
}
