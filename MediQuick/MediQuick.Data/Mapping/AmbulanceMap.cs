using MediQuick.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Mapping
{
    public class AmbulanceMap : IEntityTypeConfiguration<Ambulance>
    {
        public void Configure(EntityTypeBuilder<Ambulance> builder)
        {
            builder.ToTable("Ambulance");

            builder.HasKey(x => x.Id);

            builder.HasOne(a => a.Location)
                .WithMany(l => l.Ambulances)
                .HasForeignKey(a => a.LocationId);

            builder.HasMany(a => a.AmbulancesDevices)
                .WithOne(ad => ad.Ambulance)
                .HasForeignKey(ad => ad.AmbulanceId);
        }
    }
}
