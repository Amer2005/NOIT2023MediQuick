using MediQuick.Data.Contracts;
using MediQuick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IMediQuickDbContext dbContext;

        public PatientRepository(IMediQuickDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Patient GetById(int id)
        {
            return this.dbContext.Patients.FirstOrDefault(x => x.Id == id);
        }

        public void CreatePatient(Patient patient)
        {
            this.dbContext.Patients.Add(patient);
        }

        public void DeletePatientById(int id)
        {
            this.dbContext.Patients.Remove(GetById(id));
        }
    }
}
