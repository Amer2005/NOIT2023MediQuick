using MediQuick.Data.Models;
using MediQuick.Services.Contracts;
using MediQuick.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediQuick.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapApiController : ControllerBase
    {
        private const string UsernameCookieName = "username";
        private const string PasswordCookieName = "password";

        private readonly IUserService userService;
        private readonly IAmbulanceService ambulanceService;

        public MapApiController(IUserService userService, IAmbulanceService ambulanceService)
        {
            this.userService = userService;
            this.ambulanceService = ambulanceService;
        }

        [HttpPost("UpdateAmbulanceLocation")]
        public IActionResult UpdateAmbulanceLocation(UpdateAmbulanceMapLocationModel model)
        {
            string? username = Request.Cookies[UsernameCookieName];
            string? password = Request.Cookies[PasswordCookieName];
            
            User user = userService.GetUserByUsernameAndPassword(username, password);

            if (user == null)
            {
                return Unauthorized("User not found");
            }

            Ambulance ambulance = ambulanceService.GetAmbulanceByUserId(user.Id);

            if (ambulance == null)
            {
                return NotFound("Ambulance not found");
            }

            if (ambulance.User == null)
            {
                return NotFound("Ambulance driver not found");
            }

            ambulanceService.UpdateAmbulanceLocation(ambulance, model.Latitude, model.Longitude);

            return Ok("Updated"); 
        }
    }
}
