using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.src.Helpers;
using controleDeContactos.src.Models;
using controleDeContactos.src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace controleDeContactos.src.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase, IContactController
    {
        private readonly IContactRepository _contactRepository;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IContactRepository contactRepository, ILogger<ContactController> logger)
        {
            this._contactRepository = contactRepository;
            this._logger = logger;
        }
        [HttpPost]
        public async Task<ActionResult<ContactModel>> Create([FromBody] ContactModel contactModel)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                ContactModel _contactModel = await _contactRepository.Create(contactModel);
                return Ok(_contactModel);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured!");
                return StatusCode(405, "Error Message");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactModel>>> ReadAll()
        {
            try
            {
                /*List<ContactModel> _list = await _contactRepository.ReadAll();
                if(_list == null || !_list.Any()) return NotFound("Empty list");
                return Ok(_list);*/
                var contacts = await _contactRepository.ReadAll();
                return Ok(contacts);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured!");
                return StatusCode(406, "Error Message");
            }
        }

        [HttpPut]
        public async Task<ActionResult<ContactModel>> Update([FromBody] ContactModel contactModel, int id)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var existContact = await _contactRepository.FindByID(id);
                if(existContact == null) return NotFound($"Contact with ID {id} not found.");
                contactModel.Id = id;
                ContactModel _contact = await _contactRepository.Update(contactModel, id);
                return Ok(_contact);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured!");
                return StatusCode(407, "Error Message");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactModel>> Delete(int id)
        {
            try
            {
                var _remove = await _contactRepository.FindByID(id);
                if(_remove == null) return NotFound($"Contact with ID {id} not found.");
                await _contactRepository.Delete(id);
                return NoContent();
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured!");
                return StatusCode(408, "Error Message");
            }
        }

        [Route("name/{name}")]
        [HttpGet]
        public async Task<ActionResult<ContactModel>> FindByName(string name)
        {
            try
            {
                List<ContactModel> _list = await _contactRepository.FindByName(name);
                if(_list == null || !_list.Any()) return NotFound($"Name : {name}, not found.");
                return Ok(_list);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured!");
                return StatusCode(409, "Error Message");
            }
        }

        [Route("id/{id}")]
        [HttpGet]
        public async Task<ActionResult<ContactModel>> FintdByID(int id)
        {
            try
            {
                ContactModel _contactID = await _contactRepository.FindByID(id);
                if(_contactID == null) return NotFound($"Contact with ID {id} not found.");
                return Ok(_contactID);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured!");
                return StatusCode(410, "Error Message");
            }
        }

        [Route("nelp")]
        [HttpGet]
        public async Task<ActionResult> ReadNLEP()
        {
            try
            {
                var contacts = await _contactRepository.ReadNLEP();
                return Ok(contacts);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured!");
                return StatusCode(406, "Error Message");
            }
        }

        [Route("filter")]
        [HttpGet]
        public async Task<ActionResult> FilterNL([FromQuery] QueryObject query)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var contacts = await _contactRepository.FilterNL(query);
                return Ok(contacts);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured!");
                return StatusCode(406, "Error Message");
            }
        }
    }
}