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
       
      
        [HttpPut("UpdateContact")]
        public ActionResult Update([FromRoute] int Cid, [FromBody] Modules.TrContact tr)
        {
            try
            {
                if (Cid != 0)
                {
                    _ctlogic.UpdateTrContact(Cid, tr);
                    return Ok(tr);
                }
                else
                    return BadRequest($"something wrong with {tr.Cid} input, please try again!");
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

        [HttpDelete("DeleteContact")]
      
        public IActionResult Delete(string City)
        {
            try
            {
                if (!string.IsNullOrEmpty(City))
                {
                    var city = _ctlogic.DeleteTrContact(City);
                    if (city != null)
                        return Ok(city);
                    else
                        return NotFound();
                }
                else
                    return BadRequest("Please add a valid City name to be deleted");

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
