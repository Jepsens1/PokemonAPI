using PokemonAPI.Models;
namespace PokemonAPI.Managers
{
    public class PokemonManager
    {
        DataAccess dataAccess;
        List<Pokemon> pokemons = new List<Pokemon>();
        public Pokemon GetPokemonByName(string name)
        {
            try
            {
                dataAccess = new DataAccess();
                return dataAccess.GetPokemonByName(name.ToLower());
            }
            catch (Exception)
            {

                throw new Exception();
            }

        }
        public List<Pokemon> GetAllPokemens()
        {
            try
            {
                dataAccess = new DataAccess();
                return dataAccess.GetAllPokemons(pokemons);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        public Pokemon GetPokemonDetailsFromID(int id)
        {
            try
            {
                dataAccess = new DataAccess();
                return dataAccess.GetPokemonDetailsFromID(id);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
