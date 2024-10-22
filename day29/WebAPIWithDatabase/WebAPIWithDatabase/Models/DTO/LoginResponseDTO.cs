using Microsoft.AspNetCore.Mvc;

namespace WebAPIWithDatabase.Models.DTO
{
    public class LoginResponseDTO
    {
        public string Username { get; set; }=string.Empty;
        public string Token {  get; set; }=string.Empty;

        //public static implicit operator LoginResponseDTO(ActionResult<LoginResponseDTO> v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
