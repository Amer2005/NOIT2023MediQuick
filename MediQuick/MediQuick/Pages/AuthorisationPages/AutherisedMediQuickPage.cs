using MediQuick.Data.Models;
using MediQuick.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediQuick.Pages.AuthorisationPages
{
    public class AutherisedMediQuickPage : BaseMediQuickPage
    {
        public AutherisedMediQuickPage(IUserService userService) : base(userService)
        {
        }

        public override IActionResult OnGet()
        {
            base.OnGet();

            if(LoggedUser == null)
            {
                return Redirect("/Index");
            }

            return Page();
        }

        
    }
}
