using MediQuick.Data.Enums;
using MediQuick.Data.Models;
using MediQuick.Services.Contracts;
using MediQuick.Web.Models;
using MediQuick.Web.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MediQuick.Web.Controllers
{
    public class HospitalController : BaseController
    {
        private readonly IAmbulanceService ambulanceService;

        public HospitalController(IUserService userService, IAmbulanceService ambulanceService) : base(userService)
        {
            this.ambulanceService = ambulanceService;
        }


        [HttpGet]
        public IActionResult ViewHospitalAmbulances(ViewHospitalAmbulancesModel model)
        {
            SetUpBaseModel(model);

            if (!model.User.UsersRoles.Select(x => x.Role.Name).Contains(RoleType.Admin.ToString()) &&
                (model.User.UsersRoles.Select(x => x.Role.Name).Contains(RoleType.HospitalEmployee.ToString()) ||
                 model.User.UsersRoles.Select(x => x.Role.Name).Contains(RoleType.HospitalAdmin.ToString())))
            {
                model.HospitalId = model.User.HospitalId;
            }

            List<Ambulance> ambulances = ambulanceService.GetAllAmbulancesFromHospital((int)model.HospitalId);

            model.AmbulanceStatuses = ambulances
                .Select(x => new AmbulanceStatus(x.User.Name, !(x.PatientId == null), x.Id))
                .ToList();

            return View(model);
        }
    }
}
