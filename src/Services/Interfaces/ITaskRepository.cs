using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.src.Models;
/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.src.Services.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskModel> Create(TaskModel taskModel);
        Task<List<TaskModel>> ReadAll();
        Task<TaskModel> Update(TaskModel taskModel, int id);
        Task<bool> Delete(int id);
        Task<TaskModel> FindByID(int id);
    }
}