using MediQuick.Data.Models;
using MediQuick.Services.Contracts;
using MediQuick.Web.Models;
using MediQuick.Web.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MediQuick.Web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IHospitalService hospitalService;
        private readonly IRoleService roleService;

        public AdminController(IUserService userService, IHospitalService hospitalService, IRoleService roleService) : base(userService)
        {
            this.hospitalService = hospitalService;
            this.roleService = roleService;
        }

        [HttpGet]
        public IActionResult CreateUser(CreateUserModel model)
        {
            SetUpBaseModel(model);

            model.RoleIds = new List<int>();

            model.Hospitals = hospitalService.GetAllHospitals();
            model.Roles = roleService.GetAllRoles();

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateUserPost(CreateUserModel model)
        {
            SetUpBaseModel(model);

            if (model.Password != model.RepeatPassword)
            {
                model.Messages.Add(new Message("Password and Repeat password must match", MessageType.Error));
                return View("CreateUser", model);
            }

            if(!userService.CreateUser(model.Username, model.Password, model.HospitalId, model.RoleIds))
            {
                model.Messages.Add(new Message("User creation failed", MessageType.Error));
                return View("CreateUser", model);
            }

            model.Messages.Add(new Message("User created successfully", MessageType.Success));
            return View("CreateUser", model);
        }
    }
}
