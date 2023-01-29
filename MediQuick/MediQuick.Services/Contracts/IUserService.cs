using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Services.Contracts
{
    public interface IUserService
    {
        bool LoginUser(string username, string password);
    }
}
