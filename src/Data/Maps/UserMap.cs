using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.Enums;
using controleDeContactos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            try
            {
                builder.ToTable("tbUser");
                builder.HasKey(u => u.Id);
                builder.Property(u => u.Id)
                .HasColumnName("id")
                .HasColumnType("bigint unsigned")
                .ValueGeneratedOnAdd()
                .IsRequired();

                builder.HasIndex(u => u.FullName).IsUnique();
                builder.Property(u => u.FullName)
                .HasColumnName("fullName")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();

                builder.HasIndex(u => u.Email).IsUnique();
                builder.Property(u => u.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();

                builder.HasIndex(u => u.UserName).IsUnique();
                builder.Property(u => u.UserName)
                .HasColumnName("userName")
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

                builder.Property(u => u.Password)
                .HasColumnName("password")
                .HasColumnType("varchar(75)")
                .HasMaxLength(75)
                .IsRequired();

                builder.Property<UserProfileEnum>(u => u.Profile)
                .HasColumnName("profile")
                .HasDefaultValue(UserProfileEnum.Pattern)
                .IsRequired();

                builder.Property<UserStatusEnum>(u => u.Status)
                .HasColumnName("status")
                .HasDefaultValue(UserStatusEnum.Inactive)
                .IsRequired();

                builder.Property<DateTime>(u => u.DateRegister)
                .HasColumnName("dateRegister")
                .HasColumnType("datetime")
                .HasDefaultValueSql("current_timestamp")
                .IsRequired();

                builder.Property<DateTime>(u => u.DateUpdate)
                .HasColumnType("dateUpdate")
                .HasColumnType("datetime");
            }
            catch (Exception error)
            {
                throw new Exception($@"Error: {error.Message}");
            }
        }
    }
}