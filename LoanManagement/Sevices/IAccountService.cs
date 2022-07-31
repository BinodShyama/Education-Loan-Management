using LoanManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Sevices
{
    public interface IAccountService
    {
        string GetLoggedinUserId();
        string GetLoggedinUserFullName();
        User GetLoggedinUser();
        User GetUserById(string id);

        string GetLoggedinUserRoleId();
        bool IsAdmin(string id = null);
    }
    public class AccountService : IAccountService
    {
        // <summary>
        /// The _sign in manager.
        /// </summary>
        private readonly SignInManager<User> _signInManager;
        /// <summary>
        /// The _user manager.
        /// </summary>
        private readonly UserManager<User> _userManager;
        /// <summary>
        /// The _role manager.
        /// </summary>
        private readonly RoleManager<Role> _roleManager;
        /// <summary>
        /// The _role manager.
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AccountService(IServiceProvider services)
        {
            _signInManager = services.CreateScope().ServiceProvider.GetService<SignInManager<User>>();
            _userManager = services.CreateScope().ServiceProvider.GetService<UserManager<User>>();
            _roleManager = services.CreateScope().ServiceProvider.GetService<RoleManager<Role>>();
            _httpContextAccessor = services.GetService<IHttpContextAccessor>(); ;

        }

        public string GetLoggedinUserId()
        {

            var e = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
            var userId = e.Id;

            return userId;
        }

        public User GetUserById(string userId)
        {

            var e = _userManager.FindByIdAsync(userId).Result;
            return e;
        }
        public string GetLoggedinUserFullName()
        {
            var e = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
            return e.FirstName + " " + e.LastName;
        }

        public User GetLoggedinUser()
        {
            return _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;

        }

        public bool IsAdmin(string id = null)
        {
            if (string.IsNullOrEmpty(id))
            {
                return _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result.IsAdmin;
            }
            else
            {
                var e = _userManager.FindByIdAsync(id).Result;
                return e.IsAdmin;
            }
        }

        public string GetLoggedinUserRoleId()
        {
            throw new NotImplementedException();
        }
    }
}
