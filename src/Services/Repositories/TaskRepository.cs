using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.Data;
using controleDeContactos.src.Models;
using controleDeContactos.src.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.src.Services.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly dbTaskContact _dbTaskContact;
        public TaskRepository(dbTaskContact taskContact) { this._dbTaskContact = taskContact; }

        public async Task<TaskModel> Create(TaskModel taskModel)
        {
            await _dbTaskContact.Tasks.AddAsync(taskModel);
            await _dbTaskContact.SaveChangesAsync();
            return taskModel;
        }

        public async Task<List<TaskModel>> ReadAll()
        {
            /*return await _dbTaskContact.Tasks
        .Include(t => t.Contact)
        .ThenInclude(c => c.User)
        .ToListAsync();*/
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var tasks = await _dbTaskContact.Tasks
                .Include(t => t.Contact)           // Inclui Contact
                .ThenInclude(static c => c.User)          // Inclui User dentro de Contact
                .ToListAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            // Iterando sobre as tarefas e acessando User com segurança
            foreach (var task in tasks)
            {
                // Acessa User de forma segura usando o operador de navegação condicional
                var user = task.Contact?.User;

                if (user != null)
                {
                    // Lógica com o User, já que não é null
                    // Exemplo:
                    Console.WriteLine($"User: {user.UserName}");
                }
                else
                {
                    // Lógica para quando User for null
                    // Exemplo:
                    Console.WriteLine("User não encontrado para o contato.");
                }
            }

            return tasks;
        }

        public async Task<TaskModel> Update(TaskModel taskModel, int id)
        {
            TaskModel taskID = await FindByID(id) ?? throw new KeyNotFoundException("Task not found.");
            taskID.Description = taskModel.Description;
            taskID.Status = taskModel.Status;
            taskID.ContactID = taskModel.ContactID;
            _dbTaskContact.Tasks.Update(taskID);
            await _dbTaskContact.SaveChangesAsync();
            return taskID;
        }

        public async Task<bool> Delete(int id)
        {
            TaskModel taskID = await FindByID(id) ?? throw new KeyNotFoundException("Task not found.");
            _dbTaskContact.Tasks.Remove(taskID);
            await _dbTaskContact.SaveChangesAsync();
            return true;
        }

        public async Task<TaskModel> FindByID(int id) { return await _dbTaskContact.Tasks.Include(t => t.Contact).FirstOrDefaultAsync(t => t.Id == id) ?? throw new KeyNotFoundException($"{id} is not registered."); }
    }
}