using MediQuick.Data.Enums;
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
        public IActionResult ViewHospitalAmbulances(BaseModel model)
        {
            SetUpBaseModel(model);

            if(model.User == null || model.User.UsersRoles == null )
            {

            }

            return View();
        }
    }
}
