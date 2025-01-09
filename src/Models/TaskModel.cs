using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.src.Enums;
/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.src.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public StatusTask Status { get; set; }
        public DateTime DateRegister { get; set; }
        public int? ContactID { get; set; }
        public ContactModel? Contact { get; set; }
    }
}