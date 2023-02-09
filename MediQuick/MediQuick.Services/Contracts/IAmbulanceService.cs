using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Services.Contracts
{
    public interface IAmbulanceService
    {
        void CreateAmbulance(int hospitalId);
    }
}
