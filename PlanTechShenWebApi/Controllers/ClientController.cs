
using Microsoft.AspNetCore.Mvc;
using PlanTechShenWebApi.Data;
using PlanTechShenWebApi.ENums;
using PlanTechShenWebApi.Interfaces;
using PlanTechShenWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlanTechshenAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUserDbRepository _userDbRepository;

        public ClientController(IUserDbRepository userDbRepository)
        {
            _userDbRepository = userDbRepository;
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] Client client)
        {
            try
            {
                if (client == null || !ModelState.IsValid)
                {
                    return BadRequest(SystemErrorCodes.UserNotValid.ToString());
                }
                bool clientExists = _userDbRepository.DoesClientExistByEmailAddress(client.EmailAddress);
                if (clientExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, SystemErrorCodes.ClientDuplicate.ToString());
                }
                _userDbRepository.CreateNewClient(client);
            }
            catch (Exception)
            {
                return BadRequest(SystemErrorCodes.ClientCreationFailed.ToString());
            }
            return Ok(client);
        }

        [HttpGet]
        
            // GET api/<CustomerController>/5
            [HttpGet("byid")]
        public Client Get([FromQuery] int id)
        {
            return _userDbRepository.GetClientById(id);
        }

        [HttpGet("search")]
        public Client Get([FromQuery] string Surname)
        {
            return _userDbRepository.GetClientBySurname(Surname);
        }
      //  public Client Get([FromQuery]) int 

    }
}
