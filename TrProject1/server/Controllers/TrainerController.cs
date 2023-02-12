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
    public class TrainerController : Controller
    {
        Tvalidation _v;
        ILogic _logic;
        public TrainerController(Tvalidation v,ILogic logic)
        {
            _v = v;
            _logic = logic;
            
        }

        [HttpPost("signUp")]
        public ActionResult Post(Modules.TrDetails tr)
        {
            try
            {
                if (_v.isEmailPresent(tr.Email) == false)
                {
                    return Ok(_logic.AddTrDetails(tr));
                }
                else
                {
                    return BadRequest("Email already exists,please sign in");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ", Please try again");
            }
        }
        [HttpGet("signIn")]
        public ActionResult SignIn(string Email, string Password)
        {
            if (_v.isEmailPresent(Email) == true)
            {
                if (_v.signIn(Email, Password))
                {
                    return Ok("Successful login");
                }
                else
                {
                    return BadRequest("Wrong passowrd");
                }
            }
            else
            {
                return BadRequest("Email does not exists,please sign up");
            }
        }
    }
}
