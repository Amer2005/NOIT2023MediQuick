using MediQuick.Data.Contracts;
using MediQuick.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly IMediQuickDbContext dbContext;

        public HospitalRepository(IMediQuickDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Hospital> GetAllHospitals()
        {
            return dbContext.Hospitals.ToList();
        }

        public void AddHospital(Hospital hospital)
        {
            dbContext.Hospitals.Add(hospital);
        }

        public Hospital GetHospitalById(int id)
        {
            return dbContext.Hospitals.Include(x => x.Location).FirstOrDefault(x => x.Id == id);
        }
    }
}
