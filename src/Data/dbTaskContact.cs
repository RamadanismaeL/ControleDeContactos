using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.Data.Maps;
using controleDeContactos.src.Models;
using controleDeContactos.src.Data.Maps;
using Microsoft.EntityFrameworkCore;
/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.Data
{
    public class dbTaskContact : DbContext
    {
        public dbTaskContact(DbContextOptions<dbTaskContact> options) : base(options)
        {}
        public required DbSet<UserModel> Users { get; set; }
        public required DbSet<ContactModel> Contacts { get; set; }
        public required DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            try
            {
                model.ApplyConfiguration(new UserMap());
                model.ApplyConfiguration(new ContactMap());
                model.ApplyConfiguration(new TaskMap());
                base.OnModelCreating(model);
            }
            catch (Exception error) { throw new Exception($"Error : {error.Message}"); }
        }
    }
}