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
    internal class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("Role_User");

            builder.HasKey(ru => new { ru.UserId, ru.RoleId });

            builder.HasOne(ru => ru.Role)
                .WithMany(r => r.UsersRoles)
                .HasForeignKey(ru => ru.RoleId);

            builder.HasOne(ru => ru.User)
                 .WithMany(u => u.UsersRoles)
                 .HasForeignKey(ru => ru.UserId);
        }
    }
}
