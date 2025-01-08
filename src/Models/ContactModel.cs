using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.src.Models;
/**
**@author Ramadan Ismael
*/
namespace controleDeContactos.src.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DateRegister { get; set; }
        public int? UserID { get; set; }
        public virtual UserModel? User { get; set; }
    }
}