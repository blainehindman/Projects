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
using System;
using System.Drawing;
using System.Linq;

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
            if (widgit.WidgitName == null || widgit.WidgitDescription == null)
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
                widgit.WidgitDownloads = 0;
                widgit.WidgitRating = null;
                widgit.WidgitRatingTotal = 0;
                widgit.WidgitRatingsCount = 0;
                widgit.WidgitLikesCount = 0;
                widgit.WidgitViews = 0;
                widgit.WidgitCommentsCount = 0;
                //WidgitContent Data
                widgitContent.WidgitFileId = widgit.WidgitId;
                widgitContent.WidgitFile = widgitContent.WidgitFile;

                _context.Add(widgit);
                _context.Add(widgitContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Widgit_Page_Redirect), widgit);
            }
        }

        public async Task<IActionResult> Widgit_Page_Redirect(Guid? WidgitId)
        {
            Widgit widgit = await _context.Widgits.FindAsync(WidgitId);
            string client_username = User.Identity.Name;

            if (widgit == null)
            {
                return NotFound();
            }    

            if (client_username == null)
            {
                return Redirect("/Identity/Account/Register");
            }
            if (client_username != widgit.CreatorUsername)
            {
                widgit.WidgitViews = widgit.WidgitViews + 1;
                _context.Update(widgit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Widgit_Page_Guest), widgit);
            }
            if (client_username == widgit.CreatorUsername)
            {
                return RedirectToAction(nameof(Widgit_Page_Owner), widgit);
            }

            return NotFound();
        }

        public async Task<IActionResult> Widgit_Page_Guest(Widgit widgit)
        {
            var widgits = _context.Widgits.Where(u => u.WidgitId == widgit.WidgitId).ToList();
            var widgitContent = _context.WidgitContents.Where(u => u.WidgitFileId == widgit.WidgitId).ToList();
            var user = await _userManager.GetUserAsync(User);
            var widgitFeedViewModel = (from w in widgits
                                       join wc in widgitContent on w.WidgitId equals wc.WidgitFileId
                                       select new WidgitFeedViewModel()
                                       {
                                           //Wigit Data
                                           WidgitId = w.WidgitId,
                                           WidgitName = w.WidgitName,
                                           WidgitDescription = w.WidgitDescription,
                                           CreatorId = w.CreatorId,
                                           CreatorUsername = w.CreatorUsername,
                                           PublishedDate = w.PublishedDate,
                                           UpdatedDate = w.UpdatedDate,
                                           WidgitDownloads = w.WidgitDownloads,
                                           WidgitRating = w.WidgitRating,
                                           WidgitRatingsCount = w.WidgitRatingsCount,
                                           WidgitRatingTotal = w.WidgitRatingTotal,
                                           WidgitCommentsCount = w.WidgitCommentsCount,
                                           WidgitViews = w.WidgitViews,
                                           WidgitLikesCount = w.WidgitLikesCount,
                                           //Widgit Content Data
                                           WidgitFileId = wc.WidgitFileId,
                                           WidgitFile = wc.WidgitFile

                                       }).ToList();

            var Check_Like = _context.Likes.Where(u => u.WidgitId == widgit.WidgitId).Where(u => u.AuthorUsername == User.Identity.Name).ToList();
            var Check_Rating = _context.Ratings.Where(u => u.WidgitId == widgit.WidgitId).Where(u => u.AuthorUsername == User.Identity.Name).ToList();
            var Check_Follow = _context.Followers.Where(u => (u.FollowedId == widgit.CreatorId) && (u.FollowerId == user.Id)).ToList();

            WidgitLayoutModel widgitLayoutModel = new WidgitLayoutModel();

            if(Check_Like.Count() != 0)
            {
                widgitLayoutModel.Liked = true;
            }
            else if (Check_Like.Count() == 0)
            {
                widgitLayoutModel.Liked = false;
            }


            if (Check_Rating.Count() != 0)
            {
                widgitLayoutModel.Rated = true;
            }
            else if (Check_Rating.Count() == 0)
            {
                widgitLayoutModel.Rated = false;
            }

            if (Check_Follow.Count() != 0)
            {
                widgitLayoutModel.Followed = true;
            }
            else if (Check_Rating.Count() == 0)
            {
                widgitLayoutModel.Followed = false;
            }





            ViewData["Layout"] = widgitLayoutModel;

           

            return View(widgitFeedViewModel);
        }

        public async Task<IActionResult> Widgit_Page_Owner(Widgit widgit)
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> LikeUpdate(Guid WidgitId)
        {
            Widgit widgit = await _context.Widgits.FindAsync(WidgitId);
            var user = await _userManager.GetUserAsync(User);

            var Check_Like = _context.Likes.Where(u => u.WidgitId == widgit.WidgitId).Where(u => u.AuthorUsername == User.Identity.Name).ToList();
            if (Check_Like.Count() != 0)
            {
                if ((widgit == null) || (user == null))
                {
                    return Json(null);
                }

                Like like = Check_Like[0];
                widgit.WidgitLikesCount = widgit.WidgitLikesCount - 1;
                _context.Remove(like);
                _context.Update(widgit);

                await _context.SaveChangesAsync();
                return Json(0);
            }
            else
            {
                if ((widgit == null) || (user == null))
                {
                    return Json(null);
                }
                DateTime thisDay = DateTime.Today;

                Like like = new Like();
                like.LikeId = Guid.NewGuid();
                like.WidgitId = widgit.WidgitId;
                like.AuthorId = user.Id;
                like.AuthorUsername = user.UserName;
                like.LikeDate = thisDay.ToString("d");

                widgit.WidgitLikesCount = widgit.WidgitLikesCount + 1;
                _context.Update(widgit);

                _context.Add(like);
                await _context.SaveChangesAsync();
                return Json(1);
            }

        }

        public async Task<JsonResult> RatingUpdate(Guid WidgitId, int Score)
        {
            Widgit widgit = await _context.Widgits.FindAsync(WidgitId);
            var user = await _userManager.GetUserAsync(User);
            var Check_Rating = _context.Ratings.Where(u => u.WidgitId == widgit.WidgitId).Where(u => u.AuthorUsername == User.Identity.Name).ToList();

            if(Check_Rating.Count() != 0)
            {
                //update rating, not avaible at the moment
            }
            else
            {
                if ((widgit == null) || (user == null))
                {
                    return Json(null);
                }
                DateTime thisDay = DateTime.Today;
                Rating rating = new Rating();
                rating.RatingId = new Guid();
                rating.WidgitId = widgit.WidgitId;
                rating.AuthorId = user.Id;
                rating.AuthorUsername = user.UserName;
                rating.Score = Score;
                rating.RatingDate = thisDay.ToString("d");

                widgit.WidgitRatingsCount = widgit.WidgitRatingsCount + 1;
                widgit.WidgitRatingTotal = widgit.WidgitRatingTotal + Score;
                widgit.WidgitRating = CalculateRating(widgit.WidgitRatingTotal, widgit.WidgitRatingsCount);
                _context.Update(widgit);

                _context.Add(rating);
                await _context.SaveChangesAsync();
                return Json(1);
            }
            return Json(null);

        }

        public double CalculateRating(int TotalScore, int RatingsCount)
        {
            var Score = ((double)TotalScore)/((double)RatingsCount);
            return Score;
        }

        public async Task<JsonResult> Follow(Guid WidgitId)
        {
            Widgit widgit = await _context.Widgits.FindAsync(WidgitId);
            var user = await _userManager.GetUserAsync(User);
            var Check_Follow = _context.Followers.Where(u => (u.FollowedId == widgit.CreatorId) && (u.FollowerId == user.Id)).ToList();
            if (Check_Follow.Count() != 0)
            {
                //user already follows
                Follower follow = Check_Follow[0];
                var Find_Followers_Count = _context.UserFollowersCounts.Where(u => u.UserId == widgit.CreatorId).ToList();
                UserFollowersCount followersCount = Find_Followers_Count[0];

                followersCount.Followers = followersCount.Followers - 1;

                _context.Remove(follow);
                _context.Update(followersCount);
                await _context.SaveChangesAsync();

                return Json(1);
            }
            else
            {
                Follower follower = new Follower();
                UserFollowersCount userFollowersCount = new UserFollowersCount();
                var Find_Followers_Count = _context.UserFollowersCounts.Where(u => u.UserId == widgit.CreatorId).ToList();

                follower.FollowId = Guid.NewGuid();
                follower.FollowedId = widgit.CreatorId;
                follower.FollowedUsername = widgit.CreatorUsername;
                follower.FollowerId = user.Id;
                follower.FollowerUsername = user.UserName;

                _context.Add(follower);
                await _context.SaveChangesAsync();

                if (Find_Followers_Count.Count() == 0)
                {
                    //User has no Followers, create model
                    userFollowersCount.UserId = widgit.CreatorId;
                    userFollowersCount.Username = widgit.CreatorUsername;
                    userFollowersCount.Followers = 1;

                    _context.Add(userFollowersCount);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    //User has followers, update model
                    UserFollowersCount userFollowers = Find_Followers_Count[0];
                    userFollowers.Followers = userFollowers.Followers + 1;

                    _context.Update(userFollowers);
                    await _context.SaveChangesAsync();
                    return Json(1);
                }
                return Json(1);
            }
        }

        public async Task<JsonResult> DownloadRecord (Guid WidgitId)
        {
            Widgit widgit = await _context.Widgits.FindAsync(WidgitId);
            var user = await _userManager.GetUserAsync(User);
            var FindDownloadRecord = _context.DownloadRecords.Where(u => (u.WidgitId == widgit.WidgitId) && (u.ClientId == user.Id)).ToList();

            if(FindDownloadRecord.Count == 0)
            {
                DownloadRecord downloadRecord = new DownloadRecord();
                DateTime thisDay = DateTime.Today;

                downloadRecord.DownloadId = Guid.NewGuid();
                downloadRecord.WidgitId = widgit.WidgitId;
                downloadRecord.CreatorId = widgit.CreatorId;
                downloadRecord.CreatorUsername = widgit.CreatorUsername;
                downloadRecord.ClientId = user.Id;
                downloadRecord.ClientUsername = user.UserName;
                downloadRecord.DownloadDate = thisDay.ToString("d");
                _context.Add(downloadRecord);
                await _context.SaveChangesAsync();
                return Json(1);
            }
            else
            {
                return Json(1);
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
