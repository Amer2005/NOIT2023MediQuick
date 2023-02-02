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
    public class HospitalService : IHospitalService
    {
        private IHospitalRepository hospitalRepository;

        public HospitalService(IHospitalRepository hospitalRepository)
        {
            this.hospitalRepository = hospitalRepository;
        }

        public List<Hospital> GetAllHospitals()
        {
            return hospitalRepository.GetAllHospitals();
        }
    }
}
