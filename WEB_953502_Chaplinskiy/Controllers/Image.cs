using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953502_Chaplinskiy.Entities;

namespace WEB_953502_Chaplinskiy.Controllers
{
    public class Image : Controller
    {
        UserManager<ApplicationUser> _userManager;
        IWebHostEnvironment _env;

        public Image(UserManager<ApplicationUser>
userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public async Task<FileResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.AvatarImage != null)
                return File(user.AvatarImage, "image/...");
            else
            {
                var avatarPath = "/Images/Man.png";
                return File(_env.WebRootFileProvider
                .GetFileInfo(avatarPath)

                .CreateReadStream(), "image/...");

            }
        }
    }
}
