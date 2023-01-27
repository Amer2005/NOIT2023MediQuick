using MediQuick.Data.Models;
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
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.HasOne(u => u.Hospital)
                .WithMany(h => h.Users)
                .HasForeignKey(u => u.HospitalId);

            builder.HasMany(u => u.UsersRoles)
                .WithOne(ru => ru.User)
                .HasForeignKey(ru => ru.UserId);
        }
    }
}
