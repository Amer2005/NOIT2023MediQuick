using MediQuick.Data.Models;

namespace MediQuick.Services.Contracts
{
    public interface IHospitalService
    {
        List<Hospital> GetAllHospitals();
    }
}