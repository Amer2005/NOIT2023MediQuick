using MediQuick.Data.Enums;
using MediQuick.Services.Contracts;
using MediQuick.Web.Models;
using MediQuick.Web.Models.Enums;
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

        [HttpGet]
        public IActionResult AssignPatient(AssignPatientModel model)
        {
            SetUpBaseModel(model);

            model.Ambulance = ambulanceService.GetAmbulanceByUserId(model.User.Id);
            
            if (model.Ambulance.PatientId != null)
            {
                model.FirstName = model.Ambulance.Patient.FirstName;
                model.LastName = model.Ambulance.Patient.LastName;
                model.Status = model.Ambulance.Patient.Status;
                model.DateOfBirth = model.Ambulance.Patient.DateOfBirth;
                model.ExtraInfo = model.Ambulance.Patient.ExtraInfo;
                model.Sex = model.Ambulance.Patient.Sex;
                model.SocialSecurityNumber = model.Ambulance.Patient.SocialSecurityNumber;
            }

            return View(model);
        }


        [HttpPost]
        public IActionResult AssignPatientPost(AssignPatientModel model, string buttonValue)
        {
            SetUpBaseModel(model);

            if (model.User.UsersRoles.Select(x => x.Role.Name).Contains(RoleType.AmbulanceDriver.ToString()))
            {
                model.Ambulance = ambulanceService.GetAmbulanceByUserId(model.User.Id);
            }
            else
            {
                model.Ambulance = ambulanceService.GetAmbulanceById(model.AmbulanceId);
            }

            if (buttonValue == "AssignPatientPost")
            {
                

                try
                {
                    if (model.Ambulance.PatientId != null)
                    {
                        ambulanceService.RemoveAmbulancePatient(model.Ambulance.Id);


                        model.FirstName = "";
                        model.LastName = "";
                        model.SocialSecurityNumber = "";
                        model.Sex = "";
                        model.Status = "";
                        model.DateOfBirth = DateTime.Now;
                        model.ExtraInfo = "";

                        ModelState.Clear();

                        SetUpBaseModel(model);

                        model.Messages.Add(new Message("Patient was unassigned", MessageType.Success));
                        return View("AssignPatient", model);
                    }
                    else
                    {
                        ambulanceService.AssignPatientToAmbulance(
                            model.Ambulance.Id,
                            model.FirstName,
                            model.LastName,
                            model.SocialSecurityNumber,
                            model.Sex,
                            model.Status,
                            model.DateOfBirth,
                            model.ExtraInfo);

                        
                        
                        model.Messages.Add(new Message("Patient was assigned", MessageType.Success));
                        return View("AssignPatient", model);
                    }
                }
                catch (Exception)
                {
                    model = new AssignPatientModel();

                    model.Messages.Add(new Message("There was an error!", MessageType.Error));
                    return View("AssignPatient", model);
                }
            }
            else if(buttonValue == "UpdatePatientPost")
            {
                if (model.Ambulance.PatientId == null)
                {
                    model = new AssignPatientModel();

                    model.Messages.Add(new Message("Patient was not found", MessageType.Error));
                    return View("AssignPatient", model);
                }

                ambulanceService.UpdatePatientOfAmbulance(
                        model.Ambulance.Id,
                        model.FirstName,
                        model.LastName,
                        model.SocialSecurityNumber,
                        model.Sex,
                        model.Status,
                        model.DateOfBirth,
                        model.ExtraInfo);


                model.Messages.Add(new Message("Patient info was updated", MessageType.Success));
                return View("AssignPatient", model);
            }

            return View("AssignPatient", model);
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
