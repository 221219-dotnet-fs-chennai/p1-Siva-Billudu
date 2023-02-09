  using Microsoft.AspNetCore.Mvc;
  using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Modules;
using BusinessLogic;


namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
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




    }
}
