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
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly CodeWidgitCoreDBContext _context;

        public UserController(CodeWidgitCoreDBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Profile_Redirect(string UserID)
        {
            var user = await _userManager.FindByNameAsync(UserID);
            if(UserID == User.Identity.Name)
            {
                RedirectToAction(nameof(Profile_Owner), user.Id);
            }
            else if(UserID != User.Identity.Name)
            {
                RedirectToAction(nameof(Profile_Guest), user.Id);
            }

            return NotFound();
        }

        public async Task<IActionResult> Profile_Owner(string UserID)
        {
            return View();
        }

        public async Task<IActionResult> Profile_Guest(string UserID)
        {
            return View();
        }
    }
}
