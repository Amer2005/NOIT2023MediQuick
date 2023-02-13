using MediQuick.Data.Models;

namespace MediQuick.Services.Contracts
{
    public interface IPatientService
    {
        Patient CreatePatient(string firstName, string lastName, string socialSecurityNumber, string sex, string status, DateTime dateOfBirth, string extraInfo);
    }
}