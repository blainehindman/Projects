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

        public IActionResult Log_In()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Log_In_User(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                if(Security.SecurityHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                {
                    return Json("Log In Pass");
                }
                else
                {
                    return Json("Wrong Password");
                }
                
            }
            else
            {
                return Json("User Not found");
            }
            
        }

        [HttpPost]
        public JsonResult Sign_Up_User(string first_name, string last_name, string email, string username, string password, string birthday, string repassword)
        {
            User user = new User();
            user.FirstName = first_name;
            user.LastName = last_name;
            user.Email = email;
            user.Username = username;
            user.Birthday = birthday;

            var Check_Email = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            var Check_Username = _context.Users.FirstOrDefault(u => u.Username == user.Username);

            if (Check_Email == null)
            {
                if(Check_Username == null)
                {
                    if (password == repassword)
                    {
                        Guid User_ID = Guid.NewGuid();
                        string DateJoined = DateTime.Now.ToString("yyyy-M-d");

                        user.UserId = User_ID;
                        user.DateJoined = DateJoined;

                        Security.SecurityHelper.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                        user.PasswordHash = passwordHash;
                        user.PasswordSalt = passwordSalt;


                        if (ModelState.IsValid)
                        {
                            _context.Add(user);
                            _context.SaveChangesAsync();

                            return Json("User Added");
                        }
                        else
                        {
                            return Json("Please Fill In All Fields");
                        }
                    }
                    else
                    {
                        return Json("Passwords Do Not Match");
                    }
                }
                else
                {
                    return Json("Username Already Exists");
                }
            }
            else
            {
                return Json("Email Already Exists");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}