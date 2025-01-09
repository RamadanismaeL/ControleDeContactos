using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.src.Models;
using controleDeContactos.src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.src.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase, ITaskController
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ITaskRepository taskRepository, ILogger<TaskController> logger)
        {
            this._taskRepository = taskRepository;
            this._logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Create([FromBody] TaskModel taskModel)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                TaskModel _taskModel = await _taskRepository.Create(taskModel);
                return Ok(_taskModel);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "An error occured.");
                return StatusCode(411, "Error Message");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> ReadAll()
        {
            try
            {
                var tasks = await _taskRepository.ReadAll();
                return Ok(tasks);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured.");
                return StatusCode(412, "Error Message");
            }
        }

        [HttpPut]
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel taskModel, int id)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var existTask = await _taskRepository.FindByID(id);
                if(existTask == null) return NotFound($"Task with ID {id} not found.");
                taskModel.Id = id;
                TaskModel _tasks = await _taskRepository.Update(taskModel, id);
                return Ok(_tasks);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured.");
                return StatusCode(413, "Error Message");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Delete(int id)
        {
            try
            {
                var _remove = await _taskRepository.FindByID(id);
                if(_remove ==  null) return NotFound($"ID: {id} do not exist.");
                await _taskRepository.Delete(id);
                return NoContent();
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured.");
                return StatusCode(414,"Error Message");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> FindByID(int id)
        {
            try
            {
                TaskModel _taskId = await _taskRepository.FindByID(id);
                if(_taskId == null) return NotFound($"ID: {id} do not exist.");
                return Ok(_taskId);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured.");
                return StatusCode(415, "Error Message");
            }
        }
    }
}