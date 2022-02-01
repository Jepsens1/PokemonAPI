using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Managers;
using PokemonAPI.Attributes;
namespace PokemonAPI.Controllers
{
    [ApiKeyAuthenticator]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        LoginManager loginManager;
        [Route("/GetLogin")]
        [HttpPost]
        public IActionResult GetLogin(string username, string password)
        {
            if (username == String.Empty && password == String.Empty)
            {
                return BadRequest("Username and password is empty");
            }
            else if (username == String.Empty)
            {
                return BadRequest("Username is empty");
            }
            else if (password == String.Empty)
            {
                return BadRequest("Password is empty");
            }
            try
            {
                loginManager = new LoginManager();
                return Ok(loginManager.GetLogin(username, password));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
