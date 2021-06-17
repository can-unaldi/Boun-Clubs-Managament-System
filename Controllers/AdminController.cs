using BounClubs.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace BounClubs.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private IPasswordHasher<ApplicationUser> passwordHasher;
        private IClubRepository clubRepository;
        private IEventRepository eventRepository;
        public AdminController(UserManager<ApplicationUser> _userManager, IPasswordHasher<ApplicationUser> _passwordHasher, IClubRepository clubRepo, IEventRepository eventRepo)
        {
            userManager = _userManager;
            passwordHasher = _passwordHasher;
            clubRepository = clubRepo;
            eventRepository = eventRepo;
        }
        public IActionResult Index()
        {
            return View(userManager.Users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = model.UserName;
                user.Email = model.Email;

                var result = await userManager.CreateAsync(user,model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var userD = await userManager.FindByIdAsync(id);
            if (userD != null)
            {
                var result = await userManager.DeleteAsync(userD);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");

            }
            return View("Index",userManager.Users);
        }
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var userU = await userManager.FindByIdAsync(id);
            if (userU != null)
            {
                return View(userU);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id, string Password, string Email)
        {
            var userU = await userManager.FindByIdAsync(id);
            if (userU != null)
            {
                if(Email!=null)
                {
                    userU.Email = Email;

                }
                if (Password != null)
                {
                    userU.PasswordHash = passwordHasher.HashPassword(userU, Password);

                }

                var result = await userManager.UpdateAsync(userU);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("","Kullanıcı bulunamadı.");
            }
            return View(userU);
        }
        public IActionResult Clubs()
        {
            return View(clubRepository.Clubs);
        }
        public IActionResult Events()
        {
            return View(eventRepository.Events);
        }
    }
}
