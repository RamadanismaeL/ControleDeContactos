using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.src.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace controleDeContactos.src.Data.Maps
{
    public class TaskMap : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            try
            {
                builder.ToTable("tbTask");

                builder.Property(t => t.Id)
                .HasColumnName("id")
                .HasColumnType("bigint unsigned")
                .ValueGeneratedOnAdd()
                .IsRequired();
                builder.HasKey(t => t.Id);

                builder.Property(t => t.Description)
                .HasColumnName("name")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();

                builder.Property<DateTime>(t => t.DateRegister)
                .HasColumnName("dateRegister")
                .HasColumnType("datetime")
                .HasDefaultValueSql("current_timestamp")
                .IsRequired();

                builder.Property(t => t.ContactID)
                .HasColumnName("contactID")
                .HasColumnType("bigint unsigned");
                builder.HasOne(t => t.Contact);
            }
            catch (Exception error)
            {
                throw new Exception($@"Error: {error.Message}");
            }
        }
    }
}