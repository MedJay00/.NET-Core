using Infestation.Infra.Services.Interfaces;
using Infestation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Controllers
{
    public class AccountController: Controller
    {

        public UserManager<IdentityUser> _userManager { get; set; }
        public SignInManager<IdentityUser> _signInManager { get; }

        public IMessageService _messageService { get; }

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMessageService messageService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _messageService = messageService;
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(AccountRegisterViewModel viewModel)
        {
            if (ModelState.IsValid) 
            {
                var user = new IdentityUser() { Email = viewModel.Email, UserName = viewModel.Email };

                var createTask = _userManager.CreateAsync(user, viewModel.Password);

                if (createTask.Result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false);

                    _messageService.SendMessage(viewModel.Email, "you're registered");

                    return RedirectToAction("Index", "Human");
                }

                foreach (var error in createTask.Result.Errors)
                    ModelState.AddModelError("",error.Description);
            }
           

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(AccountLoginViewModel loginviewModel, [FromQuery] string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var signInTask = _signInManager.PasswordSignInAsync(loginviewModel.Email, loginviewModel.Password, loginviewModel.Remain, loginviewModel.Remain);

                if (signInTask.Result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    
                    return RedirectToAction("Index", "Human");
                }
                    

                ModelState.AddModelError("", "Incorect username or password");
            }

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Human");
        }
    }
}


