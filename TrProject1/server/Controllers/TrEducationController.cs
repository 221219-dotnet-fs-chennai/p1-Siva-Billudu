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

    }
}
