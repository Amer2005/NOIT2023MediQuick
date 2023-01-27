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
    public class CardiogramMap : IEntityTypeConfiguration<Cardiogram>
    {
        public void Configure(EntityTypeBuilder<Cardiogram> builder)
        {
            builder.ToTable("Cardiogram");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.Cardiograms)
                .HasForeignKey(x => x.PatientId);
        }
    }
}
