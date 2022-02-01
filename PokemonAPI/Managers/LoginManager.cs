namespace PokemonAPI.Managers
{
    public class LoginManager
    {
        DataAccess dataAccess;
        public Login GetLogin(string username, string password)
        {
            try
            {
                dataAccess = new DataAccess();
                return dataAccess.GetLoginInfo(username, password);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
