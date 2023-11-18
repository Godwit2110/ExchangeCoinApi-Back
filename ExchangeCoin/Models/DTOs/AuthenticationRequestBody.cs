using System.ComponentModel.DataAnnotations;

namespace ExchangeCoinApi.Models.DTOs
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [RegularExpression("^(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*])[A-Za-z\\d!@#$%^&*]{8,}$\r\n")]

        public string? Password { get; set; }
    }
}
