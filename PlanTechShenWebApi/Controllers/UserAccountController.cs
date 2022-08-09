using Microsoft.AspNetCore.Mvc;
using PlanTechShenWebApi.Data;
using PlanTechShenWebApi.ENums;
using PlanTechShenWebApi.Interfaces;
using PlanTechShenWebApi.Models;

namespace PlanTechShenWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserDbRepository _userDbRepository;

        public UserAccountController(IUserDbRepository userDbRepository)
        {
            _userDbRepository = userDbRepository;
        }

        [HttpPost]
        public IActionResult CreateUserAccount([FromBody] UserAccount userAccount)
        {
            try
            {
                if (userAccount == null || !ModelState.IsValid)
                {
                    return BadRequest(SystemErrorCodes.UserAccountNotValid.ToString());
                }
                _userDbRepository.CreateNewUserAccount(userAccount);
            }
            catch (Exception)
            {
                return BadRequest(SystemErrorCodes.userAccountCreationFailed.ToString());
            }
            return Ok(userAccount);
        }


        [HttpGet("byUserid")]
        public IList<UserAccount> Get([FromQuery] int userId)
        {
            return _userDbRepository.GetUserAccountsByUserId(userId);
        }
    }
}
