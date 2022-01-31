using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Managers;
using PokemonAPI.Attributes;
namespace PokemonAPI.Controllers
{
    [ApiKeyAuthenticator]
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : Controller
    {
        PokemonManager manager;
        [Route("/GetPokemon")]
        [HttpGet]
        public IActionResult GetPokemon(string name)
        {
            if (name == String.Empty)
                return BadRequest("Insert value wrong");
            try
            {
                manager = new PokemonManager();
                return Ok(manager.GetPokemonByName(name.ToLower()));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        [Route("/GetAllPokemons")]
        [HttpGet]
        public IActionResult GetAllPokemons()
        {
            try
            {
                manager = new PokemonManager();
                return Ok(manager.GetAllPokemens());
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        [Route("/GetPokemonDetailsFromID")]
        [HttpGet]
        public IActionResult GetPokemonDetailsFromID(int id)
        {
            try
            {
                manager = new PokemonManager();
                return Ok(manager.GetPokemonDetailsFromID(id));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
    }
}
