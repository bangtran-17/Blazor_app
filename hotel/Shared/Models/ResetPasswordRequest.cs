using System.ComponentModel.DataAnnotations;

namespace Hotel.Shared.Models
{
    public class ResetPasswordRequest
    {
        
        public string Token { get; set; } = string.Empty;
        //[Required, MinLength(6, ErrorMessage = "Please enter at least 6 characters, dude!")]
        public string Password { get; set; } = string.Empty;
        //[Required, Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}