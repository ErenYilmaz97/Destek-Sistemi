using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AspCoreSupportSystem.Areas.Admin.Models;
using AspCoreSupportSystem.Models;
using AspNetCoreIdentity.PRG;
using Business.Abstract;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreSupportSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Controller]
    public class AdminController : Controller
    {


        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAccountService _accountService;
        private readonly RoleManager<Role> _roleManager;

        public AdminController(UserManager<User> userManager, SignInManager<User> signInManager, IAccountService accountService, RoleManager<Role> roleManager )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _accountService = accountService;
            _roleManager = roleManager;
        }


        [ImportModelState]
        [HttpGet]
        [Route("Admin/Login")]
        public IActionResult Login(string ReturnUrl)
        {
            TempData["ReturnUrl"] = ReturnUrl;
            return View();
        }




        [HttpPost]
        [Route("Admin/Login")]
        [ExportModelState]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            //MODEL VALİD Mİ
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login");
            }

            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            //KULLANICI VAR MI
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı Bulunamadı.");
                return RedirectToAction("Login");

            }

            //EMAİLİ ONAYLI MI
            if (!_userManager.IsEmailConfirmedAsync(user).Result)
            {
                ModelState.AddModelError(string.Empty, "Lütfen Emailinizi Onaylayın.");
                return RedirectToAction("Login");
            }


            //HESAP KİLİTLİ Mİ?
            if (await _userManager.IsLockedOutAsync(user))
            {
                ModelState.AddModelError(string.Empty, "Hesabınız Kilitli. Daha Sonra Tekrar Deneyin.");
                return RedirectToAction("Login");
            }


            var userRoles = await _userManager.GetRolesAsync(user) as List<string>;

            if (!userRoles.Contains("Admin"))
            {
                ModelState.AddModelError(string.Empty, "Yönetici İznine Sahip Değilsiniz.");
                return RedirectToAction("Login");
            }


            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

            //GİRİŞ BAŞARISIZSA
            if (!result.Succeeded)
            {
                await _userManager.AccessFailedAsync(user);
                int failed = await _userManager.GetAccessFailedCountAsync(user);

                //3 YANLIŞ GİRİŞ
                if (failed == 3)
                {
                    //HESABI 1 DAKİKALIĞINA KİLİTLE.
                    await _userManager.SetLockoutEndDateAsync(user, new System.DateTimeOffset?(DateTimeOffset.Now.AddMinutes(1)));
                    await _userManager.ResetAccessFailedCountAsync(user); //failed == 0
                    ModelState.AddModelError(string.Empty, "Hesabınız 1 Dakikalığına Kilitlenmiştir.");
                    return RedirectToAction("Login");
                }

                ModelState.AddModelError(string.Empty, $"Email veya Şifre Yanlış. ({failed.ToString()}. Hatalı Giriş)");
                return RedirectToAction("Login");

            }

            //HERŞEY BAŞARILI İSE
            await _userManager.ResetAccessFailedCountAsync(user);

            if (TempData["ReturnUrl"] == null)
                return RedirectToAction("Index", "Home");
            else
                return Redirect(TempData["ReturnUrl"].ToString());
        }




        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/Users")]
        public IActionResult Users()
        {
            string userStatus = string.Empty;

            if (TempData["UserStatus"] != null)
            {
                userStatus = TempData["UserStatus"].ToString();
            }

            ViewBag.UserStatus = userStatus;

            var getUsers = _accountService.GetUsers();
            return View(getUsers);
        }



        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/Roles")]
        public IActionResult Roles()
        {
            string roleStatus = null;

            if (TempData["RoleStatus"] != null)
            {
                roleStatus = TempData["RoleStatus"].ToString();
            }

            ViewBag.RoleStatus = roleStatus;
            return View(_roleManager.Roles.ToList());
        }


        [Authorize(Roles = "Admin")]
        [ImportModelState]
        [HttpGet]
        [Route("Admin/CreateRole")]
        public IActionResult CreateRole()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Admin/CreateRole")]
        [ExportModelState]
        public async Task<IActionResult> CreateRole(CreateRoleModel createRoleModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateRole");
            }
            

            var role = new Role(){Name = createRoleModel.RoleName};

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }

                return RedirectToAction("CreateRole");
            }

            //SUCCEDEED
            TempData["RoleStatus"] = "RoleCreated";
            return RedirectToAction("Roles");
        }





        [Authorize(Roles = "Admin")]
        [Route("Admin/DeleteRole")]
        public async Task<IActionResult> DeleteRole(string RoleID)
        {
            var role = await _roleManager.FindByIdAsync(RoleID);


            //NULL CONTROL
            if (role == null || string.IsNullOrEmpty(RoleID))
            {
                TempData["RoleStatus"] = "RoleNotFound";
                return RedirectToAction("Roles");
            }


            IdentityResult result = await _roleManager.DeleteAsync(role);
            TempData["RoleStatus"] = "RoleDeleted";
            return RedirectToAction("Roles");


        }



        [Authorize(Roles = "Admin")]
        [ImportModelState]
        [HttpGet]
        [Route("Admin/UpdateRole")]

        public async Task<IActionResult> UpdateRole(string RoleID)
        {
            var role = await _roleManager.FindByIdAsync(RoleID);

            //NULL CONTROL
            if (role == null || string.IsNullOrEmpty(RoleID))
            {
                TempData["RoleStatus"] = "RoleNotFound";
                return RedirectToAction("Roles");
            }


            return View(new UpdateRoleModel(){RoleName =  role.Name, RoleId = role.Id});

        }



        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Admin/UpdateRole")]
        [ExportModelState]
        public async Task<IActionResult> UpdateRole(UpdateRoleModel updateRoleModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("UpdateRole");
            }

            var role = await _roleManager.FindByIdAsync(updateRoleModel.RoleId);


            role.Name = updateRoleModel.RoleName;
            await _roleManager.UpdateAsync(role);
            TempData["RoleStatus"] = "RoleUpdated";
            return RedirectToAction("Roles");

        }




        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/RoleAssign")]
        public async Task<IActionResult> RoleAssign(string UserID)
        {
            var user = await _userManager.FindByIdAsync(UserID);

            //USER NULL MI
            if (user == null)
            {
                TempData["UserStatus"] = "UserNotFound";
                return RedirectToAction("Users");
            }

            //TÜM ROLLER
            List<Role> AllRoles = _roleManager.Roles.ToList();


            //KULLANICININ ROLLERİ
            var userRoles = await _userManager.GetRolesAsync(user) as List<string>;


            RoleAssignModel roleAssignModel = new RoleAssignModel(){UserID = user.Id, NameLastname = user.Name + " " +user.Lastname};

            foreach (Role role in AllRoles)
            {
                roleAssignModel.UserRoles.Add(new UserRole()
                {
                    RoleID = role.Id,
                    RoleName = role.Name,
                    Exist = userRoles.Contains(role.Name)?true:false
                });
            }

            return View(roleAssignModel);




        }





        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Admin/RoleAssign")]
        public async Task<IActionResult> RoleAssign(RoleAssignModel roleAssignModel)
        {
            var user = await _userManager.FindByIdAsync(roleAssignModel.UserID);
            var currentUser = await _userManager.GetUserAsync(User);


            foreach (UserRole role in roleAssignModel.UserRoles)
            {
                if (role.Exist == false && role.NewValue == true)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
                else if(role.Exist == true && role.NewValue == false)
                {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
            }

            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(currentUser, true);
            TempData["UserStatus"] = "RoleAssigned";
            return RedirectToAction("Users");
        }


    }
}
