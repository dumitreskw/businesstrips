// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessTrips.Business.DTOs;
using BusinessTrips.Business.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinessTrips.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        private readonly INotyfService _notifyService;

        public RegisterModel(
            ILogger<RegisterModel> logger,
            ILoginService loginService,
            IRegisterService registerService,
            INotyfService notifyService)
        {
            _loginService = loginService;
            _registerService = registerService;
            _notifyService = notifyService;
        }
        [BindProperty]
        public RegisterDTO Input { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                _notifyService.Warning("You are already signed in!");
                return RedirectToAction("Index", "Home");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _registerService.RegisterUserAsync(Input);

                if (result.Id != string.Empty)
                {
                    await _loginService.LoginByUser(result);

                    _notifyService.Success("Your account has been created successfully.");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to register user.");
                }
            }

           return Page();
        }
    }
}
