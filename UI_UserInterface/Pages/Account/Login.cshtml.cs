using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Voedselbank.Presentation.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginInputModel Input { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Input.Email == "admin@voedselbank.com" && Input.Password == "foodbank123")
            {
                // Maak een gebruiker aan met claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Input.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // FIX: Redirect naar homepagina, maar voorkom infinite redirect
                var returnUrl = Request.Query["ReturnUrl"];
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToPage("/Index");
            }

            ErrorMessage = "Invalid email or password. Please try again.";
            return Page();
        }

        public class LoginInputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
