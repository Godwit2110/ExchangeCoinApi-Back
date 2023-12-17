using System.ComponentModel.DataAnnotations;

namespace ExchangeCoinApi.Models.DTOs
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        [RegularExpression("^(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*])[A-Za-z\\d!@#$%^&*]{8,}$\r\n")]
        public string Contrasenia { get; set; }
    }
}
