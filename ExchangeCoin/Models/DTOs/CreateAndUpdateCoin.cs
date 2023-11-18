using ExchangeCoinApi.Data.Entiities;
using System.ComponentModel.DataAnnotations;

namespace ExchangeCoinApi.Models.DTOs
{
    public class CreateAndUpdateCoin
    {
        [Required]
        public string Nombre { get; set; }
        public int? Valor { get; set; }
    }
}
