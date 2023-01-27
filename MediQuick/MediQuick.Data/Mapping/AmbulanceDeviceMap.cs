using MediQuick.Data.Models.TransitionalModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Mapping
{
    internal class AmbulanceDeviceMap : IEntityTypeConfiguration<AmbulanceDevice>
    {
        public void Configure(EntityTypeBuilder<AmbulanceDevice> builder)
        {
            builder.ToTable("AmbulancesDevices");

            builder.HasKey(ad => new { ad.AmbulanceId, ad.DeviceId });

            builder.HasOne(ad => ad.Ambulance)
                .WithMany(a => a.AmbulancesDevices)
                .HasForeignKey(ad => ad.AmbulanceId);

            builder.HasOne(ad => ad.Device)
               .WithMany(d => d.AmbulancesDevices)
               .HasForeignKey(ad => ad.DeviceId);
        }
    }
}
