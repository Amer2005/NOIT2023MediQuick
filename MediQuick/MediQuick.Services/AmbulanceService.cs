using MediQuick.Data.Contracts;
using MediQuick.Data.Enums;
using MediQuick.Data.Models;
using MediQuick.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Services
{
    public class AmbulanceService : IAmbulanceService
    {
        private readonly IAmbulanceRepository ambulanceRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IHospitalRepository hospitalRepository;
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IUnitOfWork unitOfWork;

        public AmbulanceService(IAmbulanceRepository ambulanceRepository, ILocationRepository locationRepository,
                                IHospitalRepository hospitalRepository, IUserService userService,
                                IRoleService roleService,IUnitOfWork unitOfWork)
        {
            this.ambulanceRepository = ambulanceRepository;
            this.locationRepository = locationRepository;
            this.hospitalRepository = hospitalRepository;
            this.userService = userService;
            this.roleService = roleService;
            this.unitOfWork = unitOfWork;
        }

        public Ambulance CreateAmbulance(int hospitalId)
        {
            Ambulance ambulance = new Ambulance();

            ambulance.DestinationHospitalId = hospitalId;
            ambulance.IsAvailable = true;

            Hospital hospital = hospitalRepository.GetHospitalById(hospitalId);

            Location location = new Location()
            {
                Latitude = hospital.Location.Latitude,
                Longitude = hospital.Location.Longitude
            };

            locationRepository.AddLocation(location);

            unitOfWork.Commit();

            ambulance.LocationId = location.Id;

            ambulanceRepository.AddAmbulance(ambulance);

            unitOfWork.Commit();

            return ambulance;
        }

        public void CreateAmbulanceDriver(string username, string password, int hospitalId)
        {
            User driver = userService.CreateUser(username, password, hospitalId, 
                                                    new List<int>() 
                                                    { roleService.GetRoleByName(RoleType.ambulanceDriver.ToString()).Id });

            Ambulance ambulance = this.CreateAmbulance(hospitalId);

            ambulance.UserId = driver.Id;

            unitOfWork.Commit();
        }
    }
}
