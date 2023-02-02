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

        public static bool IsAuthorised(BaseModel model)
        {
            if(!model.Authorised)
            {
                return true;
            }

            if (model == null)
            {
                return false;
            }
            else if (model.Authorised && model.User == null)
            {
                return false;
            }
            else if (model.AllowedRoles != null && model.AllowedRoles.Count > 0)
            {
                if (model.User.UsersRoles == null ||
                    model.AllowedRoles.All(x => !model.User.UsersRoles.Select(x => x.Role.Name).Contains(x)))
                {
                    return false;
                }
            }

            return true;
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
