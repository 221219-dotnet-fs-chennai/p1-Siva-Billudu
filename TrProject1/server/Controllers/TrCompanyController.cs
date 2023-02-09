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

    public class TrCompanyController : Controller
    {
        ICLogic _clogic;
        public TrCompanyController(ICLogic clogic) 
        {
            _clogic = clogic;


        }
        [HttpGet("GetTrCompany")]
        public ActionResult Get()
        {
            try
            {
                var listOfCompany = _clogic.GetTrCompany();

                return Ok(listOfCompany);
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

        [HttpPost("AddTrCompany")]
        public IActionResult Add([FromBody] Modules.TrCompany tc)
        {
            try
            {
                var newcompany = _clogic.AddTrCompany(tc);
                return Created("Add", newcompany );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
