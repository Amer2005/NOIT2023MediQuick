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
    public class AmbulanceRepository : IAmbulanceRepository
    {
        private readonly IMediQuickDbContext dbContext;

        public AmbulanceRepository(IMediQuickDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Ambulance GetByUserId(int id)
        {
            return this.dbContext.Ambulances
                .Include(x => x.User)
                .Include(x => x.Location)
                .FirstOrDefault(x => x.UserId == id);
        }

        public Ambulance GetById(int id)
        {
            return this.dbContext.Ambulances
                .Include(x => x.User)
                .Include(x => x.Location)
                .Include(x => x.Patient)
                .Include(x => x.DestinationHospital)
                .ThenInclude(x => x.Location)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Ambulance> GetAllAmbulancesFromHospital(int hospitalId)
        {
            return this.dbContext.Ambulances
                .Include(x => x.User)
                .Include(x => x.Location)
                .Where(x => x.DestinationHospitalId == hospitalId)
                .ToList();
        }

        public void AddAmbulance(Ambulance ambulance)
        {
            dbContext.Ambulances.Add(ambulance);
        }
    }
}
