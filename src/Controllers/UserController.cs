using controleDeContactos.src.Models;
using controleDeContactos.src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace controleDeContactos.src.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IUserRepository _iUserRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository iUserRepository, ILogger<UserController> logger)
        {
            this._iUserRepository = iUserRepository;
            this._logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Create([FromBody] UserModel userModel)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                UserModel _userModel = await _iUserRepository.Create(userModel);
                return Ok(_userModel);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "An error occured! - Create");
                return StatusCode(400, "Error Message.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> ReadAll()
        {
            try
            {
                List<UserModel> _listUser = await _iUserRepository.ReadAll();
                if(_listUser == null || !_listUser.Any()) return NotFound("Empty");
                return Ok(_listUser);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "An error occured! - ReadAll");
                return StatusCode(401, "Error Message.");
            }
        }

        [HttpPut]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var existUser = await _iUserRepository.FindByID(id);
                if(existUser == null) return NotFound($"User with id {id} not found.");
                userModel.Id = id;
                UserModel _userModel = await _iUserRepository.Update(userModel, id);
                return Ok(_userModel);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "An error occured! - Update");
                return StatusCode(402, "Error Message.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            try
            {
                bool _remove = await _iUserRepository.Delete(id);
                if(!_remove) return NotFound($"User with id {id} not found.");
                return NoContent();
            }
            catch (Exception error)
            {
                _logger.LogError(error, "An error occured! - Delete");
                return StatusCode(403, "Error Message");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> FindByID(int id)
        {
            try
            {
                UserModel _userID = await _iUserRepository.FindByID(id);
                if(_userID == null) return NotFound($"User with id {id} not found.");
                return Ok(_userID);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "An error occured! - FindByID");
                return StatusCode(404, "Error Message");
            }
        }
    }
}