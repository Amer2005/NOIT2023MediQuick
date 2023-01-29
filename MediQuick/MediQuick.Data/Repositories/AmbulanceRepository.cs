using MediQuick.Data.Contracts;
using MediQuick.Data.Models;
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
    }
}
