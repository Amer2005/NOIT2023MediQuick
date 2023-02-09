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
        public IActionResult CreateAmbulance(CreateAmbulanceModel model)
        {
            SetUpBaseModel(model);

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateAmbulancePost(CreateAmbulanceModel model)
        {
            try
            {
                int? hospitalId = model.HospitalId;

                SetUpBaseModel(model);

                SetUpHospitalId(model, ref hospitalId);

                ambulanceService.CreateAmbulance((int)hospitalId);

                model.Messages.Add(new Message("Ambulance created!", MessageType.Success));

                return View("CreateAmbulance", model);
            }
            catch (ArgumentException e)
            {
                BaseModel returnModel = new BaseModel();

                returnModel.Messages.Add(new Message(e.Message, MessageType.Error));

                return RedirectToAction("Index", "Home", returnModel);
            }
        }

        private void SetUpHospitalId(BaseModel model,ref int? hospitalId)
        {
            if (hospitalId == null)
            {
                if (model.User == null || model.User.HospitalId == null)
                {
                    BaseModel returnModel = new BaseModel();

                    //returnModel.Messages.Add(new Message("User hospital not found!", MessageType.Error));
                    throw new ArgumentException("Hospital not found");
                }

                hospitalId = model.User.HospitalId;
            }

            if (hospitalId != model.User.HospitalId &&
                !model.User.UsersRoles.Select(x => x.Role.Name).Contains(RoleType.admin.ToString()))
            {
                BaseModel returnModel = new BaseModel();

                throw new ArgumentException("You dont have access to this hospital!");
            }
        }
    }
}
