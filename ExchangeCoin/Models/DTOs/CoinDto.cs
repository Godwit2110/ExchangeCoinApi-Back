using System.ComponentModel.DataAnnotations;

namespace ExchangeCoinApi.Models.DTOs
{
    public class CoinDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Valor { get; set; }
        [Required]
        public string Imagen { get; set; }
    }
}
