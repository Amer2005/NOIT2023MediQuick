using MediQuick.Data.Models;
using System.Collections.Generic;

namespace MediQuick.Data.Contracts
{
    public interface IHospitalRepository
    {
        void AddHospital(Hospital hospital);
        List<Hospital> GetAllHospitals();
        Hospital GetHospitalById(int id);
    }
}