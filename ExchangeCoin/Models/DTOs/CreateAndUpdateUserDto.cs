using System.ComponentModel.DataAnnotations;

namespace ExchangeCoinApi.Models.DTOs
{
    public class CreateAndUpdateUserDto
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Contrasenia { get; set; }
        [Required]
        public string RepetirContrasenia { get; set; }
    }
}