using CodeWidgitCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;

namespace CodeWidgitCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly CodeWidgitCoreDBContext _context;

        public HomeController(ILogger<HomeController> logger, CodeWidgitCoreDBContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var widgits = _context.Widgits.ToList();
            var widgitContent = _context.WidgitContents.ToList();

            var widgitFeedViewModel = (from w in widgits join wc in widgitContent on w.WidgitId equals wc.WidgitFileId
                                       select new WidgitFeedViewModel()
                                       {
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
                                           WidgitFileId = wc.WidgitFileId,
                                           WidgitFile = wc.WidgitFile

                                       }).ToList();

            return View(widgitFeedViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}