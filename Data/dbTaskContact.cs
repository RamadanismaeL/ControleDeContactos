using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}