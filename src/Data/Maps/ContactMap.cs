using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.src.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace controleDeContactos.src.Data.Maps
{
    public class ContactMap : IEntityTypeConfiguration<ContactModel>
    {
        public void Configure(EntityTypeBuilder<ContactModel> builder)
        {
            try
            {
                builder.ToTable("tbContact");

                builder.HasKey(c => c.Id);
                builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("bigint unsigned")
                .ValueGeneratedOnAdd()
                .IsRequired();

                builder.HasIndex(c => c.Name).IsUnique();
                builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();

                builder.Property(c => c.LastName)
                .HasColumnName("lastName")
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

                builder.HasIndex(c => c.Email).IsUnique();
                builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();

                builder.Property(c => c.PhoneNumber)
                .HasColumnName("phoneNumber")
                .HasColumnType("int")
                .HasMaxLength(9);

                builder.Property<DateTime>(c => c.DateRegister)
                .HasColumnName("dateRegister")
                .HasColumnType("datetime")
                .HasDefaultValueSql("current_timestamp")
                .IsRequired();

                builder.HasOne(c => c.User);
                builder.Property(c => c.UserID)
                .HasColumnName("userID")
                .HasColumnType("bigint unsigned")
                .IsRequired();
            }
            catch (Exception error)
            {
                throw new Exception($@"Error: {error.Message}");
            }
        }
    }
}