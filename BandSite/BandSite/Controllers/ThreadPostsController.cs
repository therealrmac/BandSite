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
    public class ThreadPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThreadPostsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ThreadPosts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ThreadPost.Include(t => t.Forum);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ThreadPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threadPost = await _context.ThreadPost
                .Include(t => t.Forum)
                .SingleOrDefaultAsync(m => m.ThreadPostId == id);
            if (threadPost == null)
            {
                return NotFound();
            }

            return View(threadPost);
        }

        // GET: ThreadPosts/Create
        public IActionResult Create()
        {
            ViewData["ForumId"] = new SelectList(_context.Forum, "ForumId", "ForumMessage");
            return View();
        }

        // POST: ThreadPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThreadPostId,message,DateCreated,ForumId")] ThreadPost threadPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(threadPost);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ForumId"] = new SelectList(_context.Forum, "ForumId", "ForumMessage", threadPost.ForumId);
            return View(threadPost);
        }

        // GET: ThreadPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threadPost = await _context.ThreadPost.SingleOrDefaultAsync(m => m.ThreadPostId == id);
            if (threadPost == null)
            {
                return NotFound();
            }
            ViewData["ForumId"] = new SelectList(_context.Forum, "ForumId", "ForumMessage", threadPost.ForumId);
            return View(threadPost);
        }

        // POST: ThreadPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ThreadPostId,message,DateCreated,ForumId")] ThreadPost threadPost)
        {
            if (id != threadPost.ThreadPostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(threadPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThreadPostExists(threadPost.ThreadPostId))
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
            ViewData["ForumId"] = new SelectList(_context.Forum, "ForumId", "ForumMessage", threadPost.ForumId);
            return View(threadPost);
        }

        // GET: ThreadPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threadPost = await _context.ThreadPost
                .Include(t => t.Forum)
                .SingleOrDefaultAsync(m => m.ThreadPostId == id);
            if (threadPost == null)
            {
                return NotFound();
            }

            return View(threadPost);
        }

        // POST: ThreadPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var threadPost = await _context.ThreadPost.SingleOrDefaultAsync(m => m.ThreadPostId == id);
            _context.ThreadPost.Remove(threadPost);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ThreadPostExists(int id)
        {
            return _context.ThreadPost.Any(e => e.ThreadPostId == id);
        }
    }
}
