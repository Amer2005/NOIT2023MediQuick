using MediQuick.Data.Models;

namespace MediQuick.Data.Contracts
{
    public interface IPatientRepository
    {
        void CreatePatient(Patient patient);
        void DeletePatientById(int id);
    }
}