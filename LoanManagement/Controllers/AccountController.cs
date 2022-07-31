using LoanManagement.Application.Users.Queries.GetUserByUserName;
using LoanManagement.Domain.Entities;
using LoanManagement.ViewModel.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IMediator mediator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mediator = mediator;
        }
        [AllowAnonymous]
        public virtual async Task<IActionResult> Login()
        {
            return await Task.Run(() => View());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto data, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var model = await _mediator.Send(new GetUserByUserNameQuery { userName = data.UserName });
                    //if(model==null)
                    //{
                    //    ModelState.AddModelError("LoginError", "Username or password is incorrect.");
                    //    return await Task.Run(() => View(data));
                    //}
                    var user = _userManager.FindByNameAsync(data.UserName).Result;
                    if (!user.Status)
                    {
                        ModelState.AddModelError("LoginError", "Username or password is incorrect.");
                        return await Task.Run(() => View(data));
                    }

                    var result = await _signInManager.PasswordSignInAsync(data.UserName, data.Password, data.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return Redirect("/");
                    }
                    else
                    {

                        ModelState.AddModelError("LoginError", "Username or password is incorrect.");
                        return await Task.Run(() => View(data));
                    }
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Username or password is incorrect.");
                    return await Task.Run(() => View(data));
                }
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("LoginError", ex.ToString());
                ModelState.AddModelError("LoginError", "Username or password is incorrect.");
                return await Task.Run(() => View(data));
            }


        }
        //[Route("/admin/register", Order = 5)]
        //[AllowAnonymous]
        //public IActionResult Register()
        //{

        //    return View();
        //}
        //[Route("/admin/register", Order = 5)]
        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterDto data, string returnUrl)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            var user = new User { UserName = data.Email };
        //            user.Id = Guid.NewGuid().ToString();
        //            user.EmailConfirmed = true;
        //            var result = await _userManager.CreateAsync(user, data.Password);

        //            if (result.Succeeded)
        //            {
        //                await _signInManager.SignInAsync(user, false);
        //                return Redirect("/admin/dashboard/");
        //            }
        //            else
        //            {
        //                foreach (var error in result.Errors)
        //                {
        //                    ModelState.AddModelError("", error.Description);
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.ToString());

        //    }
        //    return await Task.Run(() => View());


        //}
        public IActionResult ChangePasswordView()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordView(string oldPassword, string newPassword)
        {
            try
            {

                var user = await _userManager.GetUserAsync(User);
                var userId = _userManager.GetUserId(User);
                if (oldPassword == newPassword)
                {
                    ModelState.AddModelError(string.Empty, "Old and New Password cannot be Similar!");
                    return View();
                }
                else
                {
                    var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
                    if (result.Succeeded)
                    {

                        await Logout();
                        return Redirect("/register/login");
                    }
                    else
                    {
                        return StatusCode(500, "Old Password does not match!");
                    }
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "unable to change password.");
            }
        }

        [Route("/Account/ForgetPassword")]
        [AllowAnonymous]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            //await Request.HttpContext.SignOutAsync(
            //    CookieAuthenticationDefaults.AuthenticationScheme);

            await _signInManager.SignOutAsync();
            return Redirect("/account/login");
        }

    }
}
