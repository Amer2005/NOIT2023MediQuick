using MediQuick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Services.Contracts
{
    public interface IUserService
    {
        void CreateUser(string username, string password, int hospitalId, List<int> roles);
        User? GetUserByUsernameAndPassword(string? username, string? password);
        void LoginUser(string? username, string? password);
    }
}
