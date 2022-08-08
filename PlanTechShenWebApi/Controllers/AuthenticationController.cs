

using PlanTechShenAppWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanTechShenWebApi.Models;
using PlanTechShenWebApi.ENums;
using PlanTechShenWebApi.Data;

namespace PlanTechshenapppWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserDbRepository _userDbRepository;

        public AuthenticationController(UserDbRepository userDbRepository)
        {
            _userDbRepository = userDbRepository;
        }


        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest auth)
        {
            try
            {
                var result = _userDbRepository.PerformAuthenticationCheck(auth.Username, auth.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(SystemErrorCodes.AuthenticationFailed.ToString());
            }



        }

    }

}