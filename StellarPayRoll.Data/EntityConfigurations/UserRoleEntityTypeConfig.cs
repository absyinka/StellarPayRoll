using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarPayRoll.Core.Entities;
using System;

namespace StellarPayRoll.Data.EntityConfigurations
{
    public class UserRoleEntityTypeConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("userroles");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => new { u.UserId, u.RoleId })
                .IsUnique();

            builder.Property(u => u.RowVersion)
                .IsRowVersion();
        }
    }
}
