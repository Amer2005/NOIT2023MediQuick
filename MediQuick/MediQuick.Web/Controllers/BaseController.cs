using MediQuick.Data.Models;
using MediQuick.Services.Contracts;
using MediQuick.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediQuick.Web.Controllers
{
    public class BaseController : Controller
    {
        private const string UsernameCookieName = "username";
        private const string PasswordCookieName = "password";

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
            if (baseModel == null)
            {
                baseModel = new BaseModel();
            }

            if (Request.Cookies[UsernameCookieName] != null && Request.Cookies[PasswordCookieName] != null)
            {
                string? username = Request.Cookies[UsernameCookieName];
                string? password = Request.Cookies[PasswordCookieName];

                baseModel.User = userService.GetUserByUsernameAndPassword(username, password);
            }
        }
    }
}
