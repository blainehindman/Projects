using CodeWidgit.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeWidgit.Controllers
{
    public class HomeController : Controller
    {
        private readonly CodeWidgitCoreDBContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(CodeWidgitCoreDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Sign_Up()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Sign_Up_User(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Enter required fields");
            }
            else
            {
                Guid User_ID = Guid.NewGuid();
                string DateJoined = DateTime.Now.ToString("M-d-yyyy");
                user.UserId = User_ID;
                user.DateJoined = DateJoined;

                _context.Add(user);
                await _context.SaveChangesAsync();
                return null;
            }
        }

        public IActionResult Log_In()
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