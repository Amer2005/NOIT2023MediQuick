using MediQuick.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMediQuickDbContext dbContext;

        public UnitOfWork(IMediQuickDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
