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
    public class HospitalService : IHospitalService
    {
        private IHospitalRepository hospitalRepository;
        private readonly ILocationService locationService;
        private readonly IUnitOfWork unitOfWork;

        public HospitalService(IHospitalRepository hospitalRepository, ILocationService locationService,
                    IUnitOfWork unitOfWork)
        {
            this.hospitalRepository = hospitalRepository;
            this.locationService = locationService;
            this.unitOfWork = unitOfWork;
        }

        public List<Hospital> GetAllHospitals()
        {
            return hospitalRepository.GetAllHospitals();
        }

        public void CreateHospital(string name, decimal longitude, decimal latitude)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty!");
            }

            Location location = new Location() { Longitude = longitude, Latitude = latitude };

            locationService.CreateLocation(location);

            Hospital hospital = new Hospital();

            hospital.LocationId = location.Id;

            hospital.Name = name;

            hospitalRepository.AddHospital(hospital);

            unitOfWork.Commit();
        }
    }
}
