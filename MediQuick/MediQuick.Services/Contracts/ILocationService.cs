using MediQuick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Services.Contracts
{
    public interface ILocationService
    {
        void CreateLocation(Location location);
    }
}
