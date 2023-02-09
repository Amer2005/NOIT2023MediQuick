using MediQuick.Data.Contracts;
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
        private readonly IUnitOfWork unitOfWork;

        public AmbulanceService(IAmbulanceRepository ambulanceRepository, ILocationRepository locationRepository,
                                IHospitalRepository hospitalRepository,
                                IUnitOfWork unitOfWork)
        {
            this.ambulanceRepository = ambulanceRepository;
            this.locationRepository = locationRepository;
            this.hospitalRepository = hospitalRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateAmbulance(int hospitalId)
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
        }
    }
}
