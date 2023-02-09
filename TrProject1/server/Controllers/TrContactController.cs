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

    public class TrContactController : Controller
    {
       ICTLogic  _ctlogic;
        public TrContactController(ICTLogic ctlogic) 
        {
            _ctlogic = ctlogic;

        }
        [HttpGet("GetTrContact")]
        public ActionResult Get()
        {
            try
            {
                var listOfContact = _ctlogic.GetTrContact();

                return Ok(listOfContact);
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
        [HttpPost("AddTrContact")]
        public IActionResult Add([FromBody] Modules.TrContact tc)
        {
            try
            {
                var newcontact = _ctlogic.AddTrContact(tc);
                return Created("Add", newcontact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}
