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
    internal class HospitalMap : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.ToTable("Hospital");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Location)
                .WithMany(x => x.Hospitals)
                .HasForeignKey(x => x.LocationId);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Hospital)
                .HasForeignKey(x => x.HospitalId);
        }
    }
}
