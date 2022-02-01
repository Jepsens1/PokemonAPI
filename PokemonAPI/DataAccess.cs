using Npgsql;
using PokemonAPI.Models;

namespace PokemonAPI
{
    public class DataAccess
    {
        const string ConnectionString = "Host=localhost;Username=postgres;Password=Kode2002;Database=PokemonDB";
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
        public Login GetLoginInfo(string username, string password)
        {
            try
            {
                password = EncodePassWordToBase64(password);
                conn = new NpgsqlConnection(ConnectionString);
                conn.Open();
                cmd = new NpgsqlCommand("select * from login where username = @username AND password = @password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                reader = cmd.ExecuteReader();
                reader.Read();
                Login login = new Login((int)reader["id"], (string)reader["username"], (string)reader["password"]);
                conn.Close();
                return login;
            }
            catch (Exception)
            {
                throw new Exception();
                throw;
            }
        }
        public string EncodePassWordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception e)
            {

                throw new Exception("Error in base64Encode" + e.Message);
            }
        }
    }
}
