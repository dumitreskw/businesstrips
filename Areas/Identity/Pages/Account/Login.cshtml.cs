using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessTrips.Business.DTOs;
using BusinessTrips.Business.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinessTrips.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public LoginDTO Input { get; set; }

        private readonly ILoginService _loginService;
        private readonly INotyfService _notifyService;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(ILoginService loginService,
            ILogger<LoginModel> logger,
            INotyfService notifyService)
        {
            _loginService = loginService;
            _logger = logger;
            _notifyService = notifyService;
        }

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
            if (ModelState.IsValid)
            {
                var result = await _loginService.Login(Input);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    _notifyService.Success("You have successfully logged in to your account.");
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    _notifyService.Error("This account is locked. Contact support");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            return Page();
        }
    }
}
