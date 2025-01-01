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
                builder.HasKey(u => u.GetId());
                builder.Property(u => u.GetId())
                .HasColumnName("id")
                .HasColumnType("bigint unsigned")
                .ValueGeneratedOnAdd()
                .IsRequired();

                builder.HasIndex(u => u.GetFirstName()).IsUnique();
                builder.Property(u => u.GetFirstName())
                .HasColumnName("firstName")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();

                builder.HasIndex(u => u.GetEmail()).IsUnique();
                builder.Property(u => u.GetEmail())
                .HasColumnName("email")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();

                builder.HasIndex(u => u.GetUserName()).IsUnique();
                builder.Property(u => u.GetUserName())
                .HasColumnName("userName")
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

                builder.Property(u => u.GetPassword())
                .HasColumnName("password")
                .HasColumnType("varchar(75)")
                .HasMaxLength(75)
                .IsRequired();

                builder.Property<UserProfileEnum>(u => u.GetProfile())
                .HasColumnName("profile")
                .HasDefaultValue(UserProfileEnum.Pattern)
                .IsRequired();

                builder.Property<UserStatusEnum>(u => u.GetStatus())
                .HasColumnName("status")
                .HasDefaultValue(UserStatusEnum.Inactive)
                .IsRequired();

                builder.Property<DateTime>(u => u.GetDateRegister())
                .HasColumnName("dateRegister")
                .HasColumnType("datetime")
                .HasDefaultValueSql("current_timestamp")
                .IsRequired();
            }
            catch (Exception error)
            {
                throw new Exception($@"Error: {error.Message}");
            }
        }
    }
}