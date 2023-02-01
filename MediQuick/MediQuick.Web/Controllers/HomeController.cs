using MediQuick.Services.Contracts;
using MediQuick.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MediQuick.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUserService userService) : base(userService)
        {
        }

        public IActionResult Index(BaseModel model)
        {
            SetUpBaseModel(model);
            return View(model);
        }

        public IActionResult About(BaseModel model)
        {
            SetUpBaseModel(model);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}