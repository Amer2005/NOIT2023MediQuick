using MediQuick.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediQuick.Pages.Account
{
    public class LoginModel : PageModel
    {
        private IUserService userService;

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public bool IsValid { get; set; }

        public LoginModel(IUserService userService)
        {
            this.userService = userService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (userService.LoginUser(Username, Password))
            {
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.UtcNow.AddDays(30);
                cookieOptions.Path = "/";

                Response.Cookies.Append("username", Username, cookieOptions);
                Response.Cookies.Append("password", Password, cookieOptions);

                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
