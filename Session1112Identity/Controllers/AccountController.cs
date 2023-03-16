using Microsoft.AspNetCore.Mvc;
using Session1112Identity.Models;
using Session1112Identity.services;

namespace Session1112Identity.Controllers
{
    public class AccountController : Controller
    {
        IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        public IActionResult CreateAccount()
        {
            return View();
        }

        public async Task<IActionResult> SignUP(SignUp signUp)
        {
            var result= await accountService.CreateAccount(signUp);
            
            ViewData["result"] = result;
            
            return View("CreateAccount");
        }

        public IActionResult Login1()
        {
            return View("Login");
        }

        public async Task<IActionResult> CheckPassword(SignIn signIn)
        {
            var result=await accountService.SignIn(signIn);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");

            }else
            {
                ViewData["result"] = "Invalid Username or Password";
            return View("Login");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await accountService.Logout();
            return RedirectToAction("Login1", "Account");
            //return View("Login");

        }

        public IActionResult NewRole()
        {
            return View();
        }

        public async Task<IActionResult> AddRole(Role role)
        {
            var result= await accountService.AddRole(role);

            ViewData["result"] = result;

            return View("NewRole");
        }

        public IActionResult UserList()
        {
			List<UsersDTO> users = accountService.getUsers();
			return View(users);
			
        }

        public async Task<IActionResult> UserRoles(string Name,string UserId)
        {
            ViewData["Name"] = Name;

			List<UserRoles> userRoles= await accountService.getRoles(UserId);

			return View(userRoles);
		}

        public async Task< IActionResult> UpdateRole(List<UserRoles> userRoles)
        {
            await accountService.UpdateUserRoles(userRoles);
			userRoles = await accountService.getRoles(userRoles[0].UserId);
			return View("UserRoles", userRoles);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

	}
}
