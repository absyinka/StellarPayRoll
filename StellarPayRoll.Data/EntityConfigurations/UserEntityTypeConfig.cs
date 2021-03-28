using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarPayRoll.Core.Entities;
using System;



namespace StellarPayRoll.Data.EntityConfigurations
{
    public class UserEntityTypeConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(c => c.Email)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.PasswordHash)
                .HasColumnType("varchar(750)")
                .IsRequired();

            builder.Property(u => u.HashSalt)
                .HasColumnType("varchar(700)")
                .IsRequired();

            builder.Property(u => u.RowVersion)
                .IsRowVersion();

            builder.HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
