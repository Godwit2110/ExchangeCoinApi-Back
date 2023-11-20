using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeCoinApi.Entities
{
    public class Coin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]       
        public string Nombre { get; set; }
        [Required]
        public int Valor { get; set; }
        [Required]
        public string? Imagen { get; set; }

        [ForeignKey("UserId")]

        public int UserId { get; set; }
        public User User { get; set; }
    }

}
