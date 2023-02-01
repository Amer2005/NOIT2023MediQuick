using MediQuick.Data.Models;
using MediQuick.Services.Contracts;
using MediQuick.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediQuick.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IUserService userService;

        public BaseController(IUserService userService)
        {
            this.userService = userService;
        }

        protected void SetUpBaseModel(BaseModel baseModel)
        {
            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            {
                string? username = Request.Cookies["username"];
                string? password = Request.Cookies["password"];

                baseModel.User = userService.GetUserByUsernameAndPassword(username, password);
            }
        }
    }
}
