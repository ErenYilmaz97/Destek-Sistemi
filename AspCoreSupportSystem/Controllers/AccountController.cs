using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreSupportSystem.Models;
using AspNetCoreIdentity.PRG;
using Business.Abstract;
using DataAccess.Dto;
using Entities.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreSupportSystem.Controllers
{

    [Controller]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAccountService _accountService;
        private readonly ICityService _cityService;

        //DI
        public AccountController(UserManager<User> userManager, IAccountService accountService,
            ICityService cityService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _accountService = accountService;
            _cityService = cityService;
            _signInManager = signInManager;
        }



        [HttpGet]
        public async Task<IActionResult> Profile(string UserID)
        {
            string profileStatus = string.Empty;

            if (TempData["ProfileStatus"] != null)

            {
                profileStatus = TempData["ProfileStatus"].ToString();
            }



            var user = await _userManager.GetUserAsync(User);
            ViewBag.isAdmin = User.IsInRole("Admin");
            UserProfileListDto userprofile = _accountService.GetUserProfile(user.Id, profileStatus);


            return View(userprofile);
        }





        [ImportModelState]
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.isAdmin = User.IsInRole("Admin");
            return View();
        }




        [HttpPost]
        [ExportModelState]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ChangePassword");
            }

            var user = await _userManager.GetUserAsync(User);

            var checkPassword = await _userManager.CheckPasswordAsync(user, changePasswordModel.OldPassword);

            if (!checkPassword)
            {
                ModelState.AddModelError(string.Empty, "Eski Şifreniz Yanlış.");
                return RedirectToAction("ChangePassword");
            }

            var result = await _userManager.ChangePasswordAsync(user, changePasswordModel.OldPassword, changePasswordModel.NewPassword);


            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return RedirectToAction("ChangePassword");
            }


            //SUCCEDED

            await _userManager.UpdateSecurityStampAsync(user);
            TempData["ProfileStatus"] = "ChangedPassword";
            return RedirectToAction("Profile");
        }




        [ImportModelState]
        [HttpGet]
        public async Task<IActionResult> UserUpdate()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.isAdmin = User.IsInRole("Admin");

            UserProfileListDto userProfileModel = _accountService.GetUserProfile(user.Id);
            userProfileModel.Cities = _cityService.GetCities();

            return View(userProfileModel);
        }



        [HttpPost]
        [ExportModelState]
        public async Task<IActionResult> UserUpdate(UserProfileListDto userProfileListModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("UserUpdate");
            }

            var user = await _userManager.GetUserAsync(User);

            user.Name = userProfileListModel.Name;
            user.Lastname = userProfileListModel.Lastname;
            user.PhoneNumber = userProfileListModel.PhoneNumber;
            user.CityID = userProfileListModel.CityID;
            user.Gender = (int)userProfileListModel.Gender;
            user.Address = userProfileListModel.Address;
            user.BirthDay = userProfileListModel.BirthDay;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return RedirectToAction("UserUpdate");
            }

            //SUCCEEDED

            await _userManager.UpdateSecurityStampAsync(user);
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, true);
            TempData["ProfileStatus"] = "ProfileUpdated";
            return RedirectToAction("Profile");

        }



        [Route("/Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "User");
        }



    }
}
