using MediQuick.Data.Models;

namespace MediQuick.Services.Contracts
{
    public interface IHospitalService
    {
        void CreateHospital(string name, decimal longitude, decimal latitude);
        List<Hospital> GetAllHospitals();
    }
}