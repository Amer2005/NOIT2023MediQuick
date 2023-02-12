using MediQuick.Data.Enums;
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
        private readonly IAmbulanceService ambulanceService;

        public AdminController(IUserService userService,
                                IHospitalService hospitalService,
                                IRoleService roleService,
                                IAmbulanceService ambulanceService) : base(userService)
        {
            this.hospitalService = hospitalService;
            this.roleService = roleService;
            this.ambulanceService = ambulanceService;
        }

        [HttpGet]
        public IActionResult CreateUser(CreateUserModel model)
        {
            SetUpBaseModel(model);

            model.RoleIds = new List<int>();

            model.Hospitals = hospitalService.GetAllHospitals();

            if (!model.User.UsersRoles.Select(x => x.Role.Name).Contains(RoleType.Admin.ToString()) &&
                model.User.UsersRoles.Select(x => x.Role.Name).Contains(RoleType.HospitalAdmin.ToString()))
            {
                model.Roles = roleService.GetSpecificRoles(new List<RoleType>() { RoleType.AmbulanceDriver, RoleType.HospitalEmployee });
            }
            else
            {
                model.Roles = roleService.GetAllRoles();
            }

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

            try
            {

                User user = userService.CreateUser(model.Username,
                    model.Password,
                    model.HospitalId ?? (int)model.User.HospitalId,
                    model.RoleIds);

                List<Role> selectedRoles = model.RoleIds.Select(x => roleService.GetRoleById(x)).ToList();

                if (selectedRoles.Any(x => x.Name == RoleType.AmbulanceDriver.ToString()))
                {
                    ambulanceService.AssignAmbulance(user.Id, model.User.HospitalId ?? (int)model.HospitalId);
                }

                model.Messages.Add(new Message("User created successfully", MessageType.Success));

                model.Username = "";
                model.Password = "";
                model.RepeatPassword = "";
                model.RoleIds = new List<int>();
                model.HospitalId = 0;

                return View("CreateUser", model);
            }
            catch (ArgumentException e)
            {
                model.Messages.Add(new Message(e.Message, MessageType.Error));
                return View("CreateUser", model);
            }
        }

        [HttpGet]
        public IActionResult CreateHospital(CreateHospitalModel model)
        {
            SetUpBaseModel(model);


            return View(model);
        }

        [HttpPost]
        public IActionResult CreateHospitalPost(CreateHospitalModel model)
        {
            SetUpBaseModel(model);

            if (model.Latitude == 0 || model.Latitude == null || model.Longitude == 0 || model.Longitude == null)
            {
                model.Messages.Add(new Message("Please select valid Longtitute and Latitude", MessageType.Error));
                return View("CreateHospital", model);
            }

            if (String.IsNullOrEmpty(model.Name))
            {
                model.Messages.Add(new Message("Hospital name cannot be empty", MessageType.Error));
                return View("CreateHospital", model);
            }


            try
            {
                hospitalService.CreateHospital(model.Name, (decimal)model.Longitude, (decimal)model.Latitude);

                model.Messages.Add(new Message("Hospital created successfully", MessageType.Success));
                return View("CreateHospital", model);
            }
            catch (ArgumentException e)
            {
                model.Messages.Add(new Message(e.Message, MessageType.Error));
                return View("CreateHospital", model);
            }

        }


    }
}
