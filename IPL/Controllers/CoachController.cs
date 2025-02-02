using IPL.Service;
using IPLDataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        ICoachService coachService;

        public CoachController(ICoachService _coachService)
        {
          coachService = _coachService;
        }

        [HttpPost("AddCoach")]
       public async Task<IActionResult> AddCoach(Coach coachRequest)
       {
            if (coachRequest == null)
            {
                return BadRequest("Inlvaid argument of Coach type passed in the input");
            }

            if (string.IsNullOrEmpty(coachRequest.name))
            {
                return StatusCode(400, " Invalid input name provided " +  coachRequest.name);
            }

            try
            {

                var response = await coachService.CreateCoachAsync(coachRequest);
                return CreatedAtAction(nameof(AddCoach), "", response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "unknown error occured while creating data" + ex.Message);
            }



       }


        [HttpPost("GetCoachById")]
        public async Task<IActionResult> GetCoachById(int coachId)
        {

            if (coachId < 1)
            { 
              return BadRequest("CoachId should be positive interger. Invalid coachId specified : " + coachId);
            }

            try
            {
                var response = await coachService.GetCoachDetailsByIdAsync(coachId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error occured while making get request to the GetCoachById" + ex.Message);
           
            }

        }


    }
}
