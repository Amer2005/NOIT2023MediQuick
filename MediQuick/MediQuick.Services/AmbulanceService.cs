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
        private readonly IPatientService patientService;
        private readonly IPatientRepository patientRepository;
        private readonly IUnitOfWork unitOfWork;

        public AmbulanceService(IAmbulanceRepository ambulanceRepository, ILocationRepository locationRepository,
                                IHospitalRepository hospitalRepository,IPatientService patientService,
                                IPatientRepository patientRepository,
                                IUnitOfWork unitOfWork)
        {
            this.ambulanceRepository = ambulanceRepository;
            this.locationRepository = locationRepository;
            this.hospitalRepository = hospitalRepository;
            this.patientService = patientService;
            this.patientRepository = patientRepository;
            this.unitOfWork = unitOfWork;
        }

        public Ambulance GetAmbulanceByUserId(int id)
        {
            return ambulanceRepository.GetByUserId(id);
        }

        public Ambulance GetAmbulanceById(int id)
        {
            return ambulanceRepository.GetById(id);
        }

        public List<Ambulance> GetAllAmbulancesFromHospital(int hospitalId)
        {
            return ambulanceRepository.GetAllAmbulancesFromHospital(hospitalId);
        }

        public void UpdateAmbulanceLocation(Ambulance ambulance, decimal latitude, decimal longitude)
        {
            ambulance.Location.Longitude = longitude;
            ambulance.Location.Latitude = latitude;

            unitOfWork.Commit();
        }

        public void RemoveAmbulancePatient(int ambulanceId)
        {
            Ambulance ambulance = ambulanceRepository.GetById(ambulanceId);

            int patientId = (int)ambulance.PatientId;

            ambulance.PatientId = null;

            unitOfWork.Commit();

            patientRepository.DeletePatientById(patientId);

            unitOfWork.Commit();
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

        public void AssignAmbulance(int userId, int hospitalId)
        {
            Ambulance ambulance = this.CreateAmbulance(hospitalId);

            ambulance.UserId = userId;

            unitOfWork.Commit();
        }

        public void UpdatePatientOfAmbulance(int ambulanceId,
            string firstName,
            string lastName,
            string socialSecurityNumber,
            string sex,
            string status,
            DateTime dateOfBirth,
            string extraInfo
            )
        {
            Ambulance ambulance = this.GetAmbulanceById(ambulanceId);

            ambulance.Patient.FirstName = firstName;
            ambulance.Patient.LastName = lastName;
            ambulance.Patient.SocialSecurityNumber = socialSecurityNumber;
            ambulance.Patient.Sex = sex;
            ambulance.Patient.Status = status;
            ambulance.Patient.DateOfBirth = dateOfBirth;
            ambulance.Patient.ExtraInfo = extraInfo;

            unitOfWork.Commit();
        }

        public void AssignPatientToAmbulance(int ambulanceId, 
            string firstName,
            string lastName,
            string socialSecurityNumber,
            string sex,
            string status,
            DateTime dateOfBirth,
            string extraInfo
            )
        {
            Ambulance ambulance = this.GetAmbulanceById(ambulanceId);

            Patient patient = patientService.CreatePatient(firstName, lastName, socialSecurityNumber, sex, status, dateOfBirth, extraInfo);

            ambulance.PatientId = patient.Id;

            unitOfWork.Commit();
        }
    }
}
