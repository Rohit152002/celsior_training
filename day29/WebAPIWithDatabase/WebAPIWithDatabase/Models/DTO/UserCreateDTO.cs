namespace WebAPIWithDatabase.Models.DTO
{
    public class UserCreateDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; }=string.Empty;
        public Roles Roles { get; set; }
    }
}
