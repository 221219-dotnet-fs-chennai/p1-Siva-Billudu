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

    public class TrSkillContoller : Controller
    {
        ISkillLogic _slogic;
        public TrSkillContoller(ISkillLogic slogic)
        {
            _slogic = slogic;


        }
        [HttpGet("GetTrSkill")]
        public IActionResult Index()
        {

            try
            {
                var listOfSkill = _slogic.GetTrSkill();

                return Ok(listOfSkill);
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
        [HttpPost("AddTrSkill")]
        public IActionResult Add([FromBody] Modules.TrSkill ts)
        {
            try
            {
                var newskill = _slogic.AddTrSkill(ts);
                return Created("Add", newskill);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}
