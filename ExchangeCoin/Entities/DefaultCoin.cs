using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExchangeCoinApi.Entities
{
    public class DefaultCoin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public string? Imagen { get; set; }
    }
}
