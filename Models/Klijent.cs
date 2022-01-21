using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Models
{
    [Table("Klijent")]
    public class Klijent
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(50)]
        public string Prezime { get; set; }

        [Required]
        [Range(0,999999999)]
        public int JMBG { get; set; }

        [Required]
        [Range(0,999999)]
        public int BrojLicneKarte { get; set; }

        public string Adresa { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Password { get; set; }

    }
}