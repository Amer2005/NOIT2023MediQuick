using MediQuick.Data.Mapping;
using MediQuick.Data.Models;
using MediQuick.Data.Models.TransitionalModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediQuick.Data
{
    public class MediQuickDbContext : DbContext
    {

        public MediQuickDbContext(DbContextOptions<MediQuickDbContext> options) : base(options)
        {

        }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AmbulanceMap());
            modelBuilder.ApplyConfiguration(new CardiogramMap());
            modelBuilder.ApplyConfiguration(new DeviceMap());
            modelBuilder.ApplyConfiguration(new HospitalMap());
            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new PatientMap());
            modelBuilder.ApplyConfiguration(new AmbulanceDeviceMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
        }
    }
}
