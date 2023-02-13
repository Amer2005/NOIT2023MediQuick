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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;
        private readonly IUnitOfWork unitOfWork;

        public PatientService(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            this.patientRepository = patientRepository;
            this.unitOfWork = unitOfWork;
        }

        public Patient CreatePatient(
            string firstName, 
            string lastName, 
            string socialSecurityNumber,
            string sex, 
            string status, 
            DateTime dateOfBirth, 
            string extraInfo)
        {
            Patient patient = new Patient()
            {
                FirstName = firstName,
                LastName = lastName,
                SocialSecurityNumber = socialSecurityNumber,
                Sex = sex,
                Status = status,
                DateOfBirth = dateOfBirth,
                ExtraInfo = extraInfo
            };

            patientRepository.CreatePatient(patient);

            unitOfWork.Commit();

            return patient;
        }
    }
}
