namespace PokemonAPI.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Base_Level { get; set; }
        public string Poketype { get; set; }
        public Pokemon(int _id, string _name, int _level,string poketype)
        {
            Id = _id;
            Name = _name;
            Base_Level = _level;
            Poketype = poketype;
        }
    }
}
