using System;
using System.ComponentModel.DataAnnotations;

namespace XpSprint3.Models
{
    // Modelo de dados para um cliente
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
