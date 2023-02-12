﻿using MediQuick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Services.Contracts
{
    public interface IAmbulanceService
    {
        Ambulance CreateAmbulance(int hospitalId);
        void CreateAmbulanceDriver(string username, string password, int hospitalId);
        Ambulance GetAmbulanceByUserId(int id);
        void UpdateAmbulanceLocation(Ambulance ambulance, decimal latitude, decimal longitude);
    }
}
