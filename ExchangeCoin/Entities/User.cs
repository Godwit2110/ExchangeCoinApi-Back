using ExchangeCoinApi.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeCoinApi.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Contrasenia { get; set; }
        [Required]
        public Subscription Subscriptions { get; set; }

        public int TotalConversiones { get; set; }

        [Required]
        [ForeignKey("CoinId")]
        public Coin Coin { get; set; }
        public int CoinId { get; set; }

    }
}