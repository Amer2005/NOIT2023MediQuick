﻿using MediQuick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Contracts
{
    public interface IAmbulanceRepository
    {
        void AddAmbulance(Ambulance ambulance);
        Ambulance GetByUserId(int id);
    }
}
