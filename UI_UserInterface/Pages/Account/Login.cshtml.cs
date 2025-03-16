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
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Input.Email),
            new Claim(ClaimTypes.Role, "Admin")
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // ✅ Redirect naar de gewenste pagina na inloggen
                var returnUrl = Request.Query["ReturnUrl"];
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToPage("/Food/Index"); //  Zorgt ervoor dat de gebruiker doorgestuurd wordt naar de juiste pagina
            }

            ErrorMessage = "Ongeldige email of wachtwoord. Probeer opnieuw.";
            return Page();
        }

        public class LoginInputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
