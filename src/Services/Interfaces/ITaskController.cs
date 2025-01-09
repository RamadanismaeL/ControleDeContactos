using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.src.Models;
using Microsoft.AspNetCore.Mvc;
/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.src.Services.Interfaces
{
    public interface ITaskController
    {
        Task<ActionResult<TaskModel>> Create([FromBody] TaskModel taskModel);
        Task<ActionResult<List<TaskModel>>> ReadAll();
        Task<ActionResult<TaskModel>> Update([FromBody] TaskModel taskModel, int id);
        Task<ActionResult<TaskModel>> Delete(int id);
        Task<ActionResult<TaskModel>> FindByID(int id);
    }
}