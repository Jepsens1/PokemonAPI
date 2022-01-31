using Npgsql;
using PokemonAPI.Models;

namespace PokemonAPI
{
    public class PokemonDataAccess
    {
        const string ConnectionString = "Host=localhost;Username=postgres;Password=passw0rd;Database=PokemonDB";
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        NpgsqlDataReader reader;
        public Pokemon GetPokemonByName(string name)
        {
            try
            { 
                conn = new NpgsqlConnection(ConnectionString);
                conn.Open();
                cmd = new NpgsqlCommand("select * from GetPokemonByName(@name);", conn);
                cmd.Parameters.AddWithValue("@name", name.ToLower());
                reader = cmd.ExecuteReader();
                reader.Read();
                Pokemon pokemon = new Pokemon((int)reader["id"], (string)reader["identifier"], (int)reader["pokemon_level"], (string)reader["pokemon_type"]);
                conn.Close();
                return pokemon;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public List<Pokemon> GetAllPokemons(List<Pokemon> pokemons)
        {
            try
            {
                conn = new NpgsqlConnection(ConnectionString);
                conn.Open();
                cmd = new NpgsqlCommand("select * from GetAllPokemonsFunction();", conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pokemons.Add(new Pokemon((int)reader["id"], (string)reader["identifier"], (int)reader["pokemon_level"],(string)reader["pokemon_type"]));
                }
                conn.Close();
                return pokemons;
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
                conn = new NpgsqlConnection(ConnectionString);
                conn.Open();
                cmd = new NpgsqlCommand("select * from GetPokemonByID(@id);", conn);
                cmd.Parameters.AddWithValue("@id", id);
                reader = cmd.ExecuteReader();
                reader.Read();
                Pokemon pokemon = new Pokemon((int)reader["id"], (string)reader["identifier"], (int)reader["pokemon_level"], (string)reader["pokemon_type"]);
                conn.Close();
                return pokemon;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
