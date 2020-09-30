using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreSupportSystem.Models;
using AspNetCoreIdentity.PRG;
using AspNetCoreIdentity.SMTP;
using Business.Abstract;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreSupportSystem.Controllers
{

    [Controller]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICityService _cityService;
        private readonly SignInManager<User> _signInManager;


        //DI
        public UserController(UserManager<User> userManager, ICityService cityService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _cityService = cityService;
            _signInManager = signInManager;
        }



        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("MainPage", "Petition");
            }


            return View();
        }




        [ImportModelState]
        [HttpGet]
        [Route("~/SignUp")]
        public IActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("MainPage", "Petition");
            }


            SignUpModel signUpModel = new SignUpModel() { Cities = _cityService.GetCities() };
            return View(signUpModel);
        }




        [HttpPost]
        [Route("~/SignUp")]
        [ExportModelState]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("SignUp");
            }

            User user = new User()
            {
                Name = signUpModel.Name,
                Lastname = signUpModel.LastName,
                Email = signUpModel.Email,
                PhoneNumber = signUpModel.PhoneNumber,
                UserName = signUpModel.Email,
                CityID = signUpModel.SelectedCityID

            };

            var result = await _userManager.CreateAsync(user, signUpModel.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return RedirectToAction("SignUp");
            }

            //SUCCEDED
            string confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string link = Url.Action("ConfirmEmail","User", new
            {
                userId = user.Id,
                token = confirmEmailToken,
            },HttpContext.Request.Scheme);

            bool mailResult = MailHelper.SendConfirmEmail(link, user.Email);

            if (!mailResult)
            {
                ModelState.AddModelError(string.Empty,"Bir Hata Oluştu. Daha Sonra Tekrar Deneyin.");
                return RedirectToAction("SignUp");
            }
            
            return RedirectToAction("ConfirmEmailSent");
        }





        
        [Route("/ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {

            var user = await _userManager.FindByIdAsync(userId);

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded)
            {
                ViewBag.ConfirmEmailStatus = "Bir Hata Oluştu. Daha Sonra Tekrar Deneyiniz.";
            }
            else
            {
                ViewBag.ConfirmEmailStatus = "Email Adresiniz Onaylandı! Giriş Yapabilirsiniz.";
            }

            return View();
        }



        [ImportModelState]
        [HttpGet]
        [Route("~/Login")]
        public IActionResult Login(string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("MainPage", "Petition");
            }


            TempData["ReturnUrl"] = ReturnUrl;
            return View();
        }



        [HttpPost]
        [Route("~/Login")]
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



            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, false);

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
                return RedirectToAction("MainPage", "Petition");
            else
                return Redirect(TempData["ReturnUrl"].ToString());

        }




        [ImportModelState]
        [HttpGet]
        [Route("~/ForgetPassword")]
        public IActionResult ForgetPassword()
        {
            return View();
        }





        [HttpPost]
        [Route("~/ForgetPassword")]
        [ExportModelState]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordModel forgetPasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ForgetPassword");
            }

            var user = await _userManager.FindByEmailAsync(forgetPasswordModel.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Böyle Bir Kullanıcı Bulunamadı.");
                return RedirectToAction("ForgetPassword");
            }

            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            string passwordResetLink = Url.Action("ResetPassword", "User", new
            {
                userID = user.Id,
                token = passwordResetToken,
            }, HttpContext.Request.Scheme);


            bool result = MailHelper.SendPasswordResetMail(passwordResetLink, user.Email);

            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Bir Hata Oluştu. Daha Sonra Tekrar Deneyin.");
                return RedirectToAction("ForgetPassword");
            }

            //SUCCESS
            return RedirectToAction("SentPasswordResetMail");

        }





        [HttpGet]
        [Route("~/SentPasswordResetMail")]
        public IActionResult SentPasswordResetMail()
        {
            return View();
        }





        [ImportModelState]
        [HttpGet]
        [Route("~/ResetPassword")]
        public IActionResult ResetPassword(string userID, string token)
        {
            TempData["userID"] = userID;
            TempData["token"] = token;
            return View();
        }





        [HttpPost]
        [Route("~/ResetPassword")]
        [ExportModelState]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ResetPassword");
            }

            var user = await _userManager.FindByIdAsync(TempData["userID"].ToString());

            var result = await _userManager.ResetPasswordAsync(user, TempData["token"].ToString(), resetPasswordModel.NewPassword);


            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return RedirectToAction("ResetPassword");
            }

            //SUCCEED
            return RedirectToAction("ResetPasswordSuccess");
        }







        [HttpGet]
        [Route("~/ResetPasswordSuccess")]
        public IActionResult ResetPasswordSuccess()
        {
            return View();

        }




        [HttpGet]
        public IActionResult ConfirmEmailSent()
        {
            return View();
        }




        [Route("/AccessDenied")]
        public IActionResult AccessDenied()
        {

            return View();
        }




    }
}
