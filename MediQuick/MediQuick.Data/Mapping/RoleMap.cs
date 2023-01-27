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
    internal class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.HasKey(x => x.Id);

            builder.HasMany(r => r.UsersRoles)
                .WithOne(ru => ru.Role)
                .HasForeignKey(ru => ru.RoleId);
        }
    }
}
