using MediQuick.Data.Contracts;
using MediQuick.Data.Models;
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
    }
}
