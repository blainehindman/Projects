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
            dynamic Widgit_Feed = new ExpandoObject();
            Widgit_Feed.Widgits = _context.Widgits.ToList();
            Widgit_Feed.WidgitContent = _context.WidgitContents.ToList();
            return View(Widgit_Feed);
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