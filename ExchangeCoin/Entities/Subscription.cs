﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ExchangeCoinApi.Models.DTOs;

namespace ExchangeCoinApi.Entities
{
    public class Subscription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int Subscriptions { get; set; }

        [ForeignKey("UserId")]

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
