using MediQuick.Data.Models;
using System.Collections.Generic;

namespace MediQuick.Data.Contracts
{
    public interface IHospitalRepository
    {
        List<Hospital> GetAllHospitals();
    }
}