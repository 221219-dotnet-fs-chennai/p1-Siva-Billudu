using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Modules;
using BusinessLogic;
using server.FilterModels;


namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ActionFilter]

    public class TrEducationController : Controller
    {
        IELogic _elogic;
        public TrEducationController(IELogic elogic)
        {
            _elogic =  elogic; 
        }
        [HttpGet("GetTrEducations")]
        public IActionResult Index()
        {
            try
            {
                var listOfEducation = _elogic.GetTrEducations();

                return Ok(listOfEducation);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("AddTrEducation")]
        public IActionResult Add([FromBody] Modules.TrEducation te)
        {
            try
            {
                var newEducation = _elogic.AddTrEducation(te);
                return Created("Add", newEducation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateEducation/{TrEduid}")]
        public ActionResult Update( int TrEduid, [FromBody] Modules.TrEducation te)
        {
            try
            {
                if (TrEduid != 0)
                {
                    _elogic.UpdateEducation(TrEduid, te);
                    return Ok(te);
                }
                else
                    return BadRequest($"something wrong with {te.TrEduid} input, please try again!");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteEducation")]
              public ActionResult Delete(string Tuniversity)
        {
            try
            {
                if (!string.IsNullOrEmpty(Tuniversity))
                {
                    var Trcollege = _elogic.DeleteTrEducation(Tuniversity);
                    if (Trcollege != null)
                        return Ok(Trcollege);
                    else
                        return NotFound();
                }
                else
                    return BadRequest("Please add a valid trainer name to be deleted");

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }





    }
}
