using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarPayRoll.Core.Entities;
using System;

namespace StellarPayRoll.Data.EntityConfigurations
{
    public class RoleEntityTypeConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasIndex(u => u.Name)
                .IsUnique();

            builder.Property(u => u.Description)
                .HasColumnType("varchar(500)");

            builder.Property(u => u.RowVersion)
                .IsRowVersion();

            builder.HasMany(u => u.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}
