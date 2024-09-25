namespace UnderstandingStructure.Models
{
    public interface ILogin
    {
        bool LoggedIn(string username, string password);
    }
}
