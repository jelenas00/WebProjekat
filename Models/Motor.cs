using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Models{

    [Table("Motor")]
    public class Motor
    {
        [Key]
        public int ID { get; set; }


        [Required]
        [MaxLength(70)]
        public string Model { get; set; }
        public string Boja { get; set; }

        [MaxLength(4)]
        [Range(1900,2022)]

        public int GodinaProizvodnje { get; set; }

        [Required]
        public int Cena { get; set; }

        [Range(50,4000)]
        public int Kubikaza { get; set; }

        public string Dostupnost { get; set; }
        public string Tip { get; set; }
        [JsonIgnore]
        [Required]
        public int MotoPartnerID { get; set; }
    }
}