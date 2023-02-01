using MediQuick.Data.Models;
using MediQuick.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediQuick.Pages.AuthorisationPages
{
    public class BaseMediQuickPage : PageModel
    {
        protected User? LoggedUser;

        private IUserService userService;



        public BaseMediQuickPage(IUserService userService)
        {
            this.userService = userService;
        }

        public virtual IActionResult OnGet()
        {
            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            {
                string? username = Request.Cookies["username"];
                string? password = Request.Cookies["password"];

                LoggedUser = userService.GetUserByUsernameAndPassword(username, password);
            }

            return Page();
        }

        
    }
}
