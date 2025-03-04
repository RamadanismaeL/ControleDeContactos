using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.src.Helpers;
using controleDeContactos.src.Models;
using Microsoft.AspNetCore.Mvc;

namespace controleDeContactos.src.Services.Interfaces
{
    public interface IContactController
    {
        Task<ActionResult<ContactModel>> Create([FromBody] ContactModel contactModel);
        Task<ActionResult<List<ContactModel>>> ReadAll();
        Task<ActionResult<ContactModel>> Update([FromBody] ContactModel contactModel, int id);
        Task<ActionResult<ContactModel>> Delete(int id);
        Task<ActionResult<ContactModel>> FintdByID(int id);
        Task<ActionResult<ContactModel>> FindByName(string name);
        Task<ActionResult> ReadNLEP();
        Task<ActionResult> FilterNL([FromQuery] QueryObject query);
    }
}