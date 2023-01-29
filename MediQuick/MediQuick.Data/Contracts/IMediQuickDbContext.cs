using MediQuick.Data.Models;
using MediQuick.Data.Models.TransitionalModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Contracts
{
    public interface IMediQuickDbContext : IDisposable
    {
        int SaveChanges();

        public DbSet<Ambulance> Ambulances { get; set; }
               
        public DbSet<Location> Locations { get; set; }
               
        public DbSet<Cardiogram> Cardiograms { get; set; }

        public DbSet<Device> Devices { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<AmbulanceDevice> AmbulancesDevices { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UsersRoles { get; set; }
    }
}
