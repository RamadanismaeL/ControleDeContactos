using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.Data.Maps;
using controleDeContactos.Models;
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
        public required DbSet<UserModel> User { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            try
            {
                model.ApplyConfiguration(new UserMap());
                base.OnModelCreating(model);
            }
            catch (Exception error) { throw new Exception($"Error : {error.Message}"); }
        }
    }
}