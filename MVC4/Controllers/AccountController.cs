using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC4.Extensions.Raven;
using MVC4.Models;
using MVC4.Extensions.AutoMapper;
using MVC4.ViewModels.Account;

namespace MVC4.Controllers
{

    public class AccountController : RavenController
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectFromLoginPage();
            }

            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        
        //[AllowAnonymous]
        //[HttpPost]
        //public JsonResult JsonLogin(LoginModel model, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Membership.ValidateUser(model.UserName, model.Password))
        //        {
        //            FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
        //            return Json(new { success = true, redirect = returnUrl });
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "The user name or password provided is incorrect.");
        //        }
        //    }

        //    // If we got this far, something failed
        //    return Json(new { errors = GetErrorsFromModelState() });
        //}

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            var user = RavenSession.GetUserByEmail(model.Email);
            user.Enabled = true;
            if (user == null || user.ValidatePassword(model.Password) == false)
            {
                ModelState.AddModelError("UserNotExistOrPasswordNotMatch",
                                         "Email and password do not match to any known user.");
            }
            else if (user.Enabled == false)
            {
                ModelState.AddModelError("NotEnabled", "The user is not enabled");
            }

            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.Email, true);
                return RedirectFromLoginPage(model.ReturnUrl);
            }

            return View(new LoginModel { Email = model.Email, ReturnUrl = model.ReturnUrl });
        }

        private ActionResult RedirectFromLoginPage(string retrunUrl = null)
        {
            if (string.IsNullOrEmpty(retrunUrl))
                return RedirectToAction("Index", "Home");
            return Redirect(retrunUrl);
        }

        [HttpGet]
        public ActionResult LogOff(string returnurl)
        {
            FormsAuthentication.SignOut();
            return RedirectFromLoginPage(returnurl);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View(new RegisterModel());
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult JsonRegister(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {


        //        MembershipCreateStatus createStatus;
        //        Membership.CreateUser(model.UserName, model.Password, model.Email, passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out createStatus);

        //        if (createStatus == MembershipCreateStatus.Success)
        //        {
        //            FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);
        //            return Json(new { success = true });
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", ErrorCodeToString(createStatus));
        //        }
        //    }

        //    return Json(new { errors = GetErrorsFromModelState() });
        //}

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = model.MapTo<User>();
            user.SetPassword(model.Password);
            user.Enabled = true;

            RavenSession.Store(user);

            FormsAuthentication.SetAuthCookie(model.Email, createPersistentCookie: false);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, userIsOnline: true);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

    }
}
