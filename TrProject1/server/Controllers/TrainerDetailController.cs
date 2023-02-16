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
    public class TrainerDetailController : ControllerBase
    {
        ILogic _logic;
        
        public TrainerDetailController(ILogic logic)
        {
            _logic = logic;
            
        }



        [HttpGet("GetTrDetails")]
        public ActionResult Get()
        {
            try
            {
                var listOfTrainer = _logic.GetTrDetails();

                return Ok(listOfTrainer);
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
    

        [HttpPost("AddTrDetails")]
        public IActionResult Add([FromBody] Modules.TrDetails tr)
        {
            try
            {
                var newtrainer= _logic.AddTrDetails(tr);
                return Created("Add", newtrainer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateTrainer")]
        public ActionResult Update([FromHeader] int TrId, [FromBody] Modules.TrDetails tr)
        {
            try
            {
                if (TrId != 0)
                {
                    _logic.UpdateTrDetails(TrId, tr);
                    return Ok(tr);
                }
                else
                    return BadRequest($"something wrong with {tr.TrId} input, please try again!");
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

        
        [HttpDelete("DeleteTrDetails")]
        public ActionResult Delete(string Fullname)
        {
            try
            {
                if (!string.IsNullOrEmpty(Fullname))
                {
                    var Trname = _logic.DeleteTrDetail(Fullname);
                    if (Trname != null)
                        return Ok(Trname);
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
