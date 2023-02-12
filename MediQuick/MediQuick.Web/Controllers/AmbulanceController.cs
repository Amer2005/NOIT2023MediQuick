using MediQuick.Data.Enums;
using MediQuick.Services.Contracts;
using MediQuick.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediQuick.Web.Controllers
{
    public class AmbulanceController : BaseController
    {
        private readonly IAmbulanceService ambulanceService;

        public AmbulanceController(IUserService userService, IAmbulanceService ambulanceService) : base(userService)
        {
            this.ambulanceService = ambulanceService;
        }

        public IActionResult ViewAmbulance(ViewAmbulanceModel model)
        {
            SetUpBaseModel(model);

            if (model.AmbulanceId == null)
            {
                return RedirectToAction("Index", "Home", new BaseModel());
            }

            model.Ambulance = ambulanceService.GetAmbulanceById((int)model.AmbulanceId);

            if (model.Ambulance == null)
            {
                return RedirectToAction("Index", "Home", new BaseModel());
            }

            if(!model.User.UsersRoles.Select(x => x.Role.Name).Contains(RoleType.Admin.ToString()))
            {
                if(model.User.HospitalId != model.Ambulance.DestinationHospitalId)
                {
                    return RedirectToAction("Index", "Home", new BaseModel());
                }
            }

            return View(model);
        }
    }
}
