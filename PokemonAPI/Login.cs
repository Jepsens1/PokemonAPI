namespace PokemonAPI
{
    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Login(int id, string user, string pass)
        {
            Id = id;
            Username = user;
            Password = pass;
        }
    }
}
