using MediQuick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Contracts
{
    public interface IAmbulanceRepository
    {
        void AddAmbulance(Ambulance ambulance);
        List<Ambulance> GetAllAmbulancesFromHospital(int hospitalId);
        Ambulance GetById(int id);
        Ambulance GetByUserId(int id);
    }
}
