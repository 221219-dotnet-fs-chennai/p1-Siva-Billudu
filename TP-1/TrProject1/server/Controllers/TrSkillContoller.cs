using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Modules;
using BusinessLogic;
using Microsoft.IdentityModel.Tokens;

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
        [HttpPut("UpdateSkill")]
        public ActionResult Update([FromRoute] string Skill, [FromBody] Modules.TrSkill tr)
        {
            try
            {
                if (!string.IsNullOrEmpty(Skill))
                {
                    _slogic.UpdateTrSkill(Skill, tr);
                    return Ok(tr);
                }
                else
                    return BadRequest($"something wrong with {tr.Skill} input, please try again!");
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

        [HttpDelete("DeleteSkill")]
        public ActionResult Delete(int Sid)
        {
            try
            {
                if(Sid !=0)
                {
                    var skillid = _slogic.DeleteTrSkill(Sid);
                    if (skillid != null)
                        return Ok(skillid);
                    else
                        return NotFound();
                }
                else
                    return BadRequest("Please add a valid skill id to be deleted");

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
