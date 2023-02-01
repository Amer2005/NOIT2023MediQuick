﻿using MediQuick.Services.Contracts;
using MediQuick.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediQuick.Web.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IUserService userService) : base(userService)
        {
        }

        [HttpGet("User/Login")]
        public IActionResult LoginView(LoginModel loginModel)
        {
            SetUpBaseModel(loginModel);
            return View("LoginView", loginModel);
        }

        [HttpPost]
        public IActionResult LoginUser(LoginModel model)
        {
            SetUpBaseModel(model);

            if (userService.LoginUser(model.Username, model.Password))
            {
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.UtcNow.AddDays(30);
                cookieOptions.Path = "/";

                Response.Cookies.Append("username", model.Username, cookieOptions);
                Response.Cookies.Append("password", model.Password, cookieOptions);

                return RedirectToAction("Index", "Home", new BaseModel() { Message = "Logged in"});
            }

            model.Password = null;
            model.Message = "failed";
            return View("LoginView", model);
        }
    }
}
