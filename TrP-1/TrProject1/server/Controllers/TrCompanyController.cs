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
        [HttpDelete("DeleteTrcompany")]
        public IActionResult Delete(string Cname) 
        {
            try
            {
                if (!string.IsNullOrEmpty(Cname))
                {
                    var cname = _clogic.DeleteTrCompany(Cname);
                    if (cname != null)
                        return Ok(cname);
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
