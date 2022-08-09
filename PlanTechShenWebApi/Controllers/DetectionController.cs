using Microsoft.AspNetCore.Mvc;
using PlanTechShenWebApi.ENums;
using PlanTechShenWebApi.Interfaces;
using PlanTechShenWebApi.Models;


namespace PlanTechShenWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetectionController : ControllerBase
    {
        private readonly IUserDbRepository _userDbRepository;

        public DetectionController(IUserDbRepository userDbRepository)
        {
            _userDbRepository = userDbRepository;
        }

        [HttpPost]
        public IActionResult CreateDetection([FromBody] Detection detection)
        {
            try
            {
                if (detection == null || !ModelState.IsValid)
                {
                    return BadRequest(SystemErrorCodes.DetectiontNotValid.ToString());
                }
                _userDbRepository.CreateNewDetection(detection);
            }
            catch (Exception)
            {
                return BadRequest(SystemErrorCodes.DetectionCreationFailed.ToString());
            }
            return Ok(detection);
        }


        [HttpGet("byDeviceid")]
        public IList<Detection> Get([FromQuery] int deviceId)
        {
            return _userDbRepository.GetDetectionsByDeviceId(deviceId);
        }
    }
}
