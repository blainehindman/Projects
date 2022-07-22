using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeWidgitCore.Models;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Dynamic;

namespace CodeWidgitCore.Controllers
{
    public class WidgitsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly CodeWidgitCoreDBContext _context;

        public string CreateWidgitError = "<html><script src='https://unpkg.com/sweetalert/dist/sweetalert.min.js'></script>" +
            "<script language='javascript' type='text/javascript'>" + "swal('Good job!', 'You clicked the button!', 'success');" +
            "</script></html>";

        public WidgitsController(CodeWidgitCoreDBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Widgits
        public async Task<IActionResult> Index()
        {
              return _context.Widgits != null ? 
                          View(await _context.Widgits.ToListAsync()) :
                          Problem("Entity set 'CodeWidgitCoreDBContext.Widgits'  is null.");
        }

        // GET: Widgits/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Widgits == null)
            {
                return NotFound();
            }

            var widgit = await _context.Widgits
                .FirstOrDefaultAsync(m => m.WidgitId == id);
            if (widgit == null)
            {
                return NotFound();
            }

            return View(widgit);
        }

        // GET: Widgits/Create
        public IActionResult Create()
        {
            Widgit widgit = new Widgit();
            WidgitContent widgitContent = new WidgitContent();
            WidgitViewModel DynamicWidgitModel = new WidgitViewModel();
            return View(DynamicWidgitModel);
        }

        // POST: Widgits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WidgitName,WidgitDescription,WidgitPrice")] Widgit widgit, [Bind("WidgitFile")] WidgitContent widgitContent)
        {

            var user = await _userManager.GetUserAsync(User);
            if (widgit.WidgitName == null || widgit.WidgitDescription == null || widgit.WidgitPrice == 0)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                //Widgit Data
                widgit.WidgitId = Guid.NewGuid();
                widgit.WidgitName = widgit.WidgitName;
                widgit.WidgitDescription = widgit.WidgitDescription;
                widgit.CreatorId = user.Id;
                widgit.CreatorUsername = user.UserName;
                widgit.PublishedDate = DateTime.UtcNow.ToString();
                widgit.UpdatedDate = DateTime.UtcNow.ToString();
                widgit.WidgitPrice = widgit.WidgitPrice;
                widgit.WidgitDownloads = 0;
                widgit.WidgitRating = null;
                widgit.WidgitRatingsCount = 0;
                widgit.WidgitLikesCount = 0;
                widgit.WidgitCommentsCount = 0;
                //WidgitContent Data
                widgitContent.WidgitFileId = Guid.NewGuid();
                widgitContent.WidgitFile = widgitContent.WidgitFile;

                _context.Add(widgit);
                _context.Add(widgitContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: Widgits/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Widgits == null)
            {
                return NotFound();
            }

            var widgit = await _context.Widgits.FindAsync(id);
            if (widgit == null)
            {
                return NotFound();
            }
            return View(widgit);
        }

        // POST: Widgits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("WidgitId,WidgitName,WidgitDescription,CreatorId,CreatorUsername,PublishedDate,UpdatedDate,WidgitPrice,WidgitDownloads,WidgitRating,WidgitLikesCount,WidgitCommentsCount")] Widgit widgit)
        {
            if (id != widgit.WidgitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(widgit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WidgitExists(widgit.WidgitId))
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
            return View(widgit);
        }

        // GET: Widgits/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Widgits == null)
            {
                return NotFound();
            }

            var widgit = await _context.Widgits
                .FirstOrDefaultAsync(m => m.WidgitId == id);
            if (widgit == null)
            {
                return NotFound();
            }

            return View(widgit);
        }

        // POST: Widgits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Widgits == null)
            {
                return Problem("Entity set 'CodeWidgitCoreDBContext.Widgits'  is null.");
            }
            var widgit = await _context.Widgits.FindAsync(id);
            if (widgit != null)
            {
                _context.Widgits.Remove(widgit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WidgitExists(Guid id)
        {
          return (_context.Widgits?.Any(e => e.WidgitId == id)).GetValueOrDefault();
        }
    }
}
