using MediQuick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Services.Contracts
{
    public interface IAmbulanceService
    {
        Ambulance CreateAmbulance(int hospitalId);

        void AssignAmbulance(int userId, int hospitalId);

        Ambulance GetAmbulanceByUserId(int id);

        void UpdateAmbulanceLocation(Ambulance ambulance, decimal latitude, decimal longitude);
        List<Ambulance> GetAllAmbulancesFromHospital(int hospitalId);
        Ambulance GetAmbulanceById(int id);
        void AssignPatientToAmbulance(int ambulanceId, string firstName, string lastName, string socialSecurityNumber, string sex, string status, DateTime dateOfBirth, string extraInfo);
        void RemoveAmbulancePatient(int ambulanceId);
    }
}
