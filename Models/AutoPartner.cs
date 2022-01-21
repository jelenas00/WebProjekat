using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Models
{
    [Table("AutoPartner")]
    public class AutoPartner
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ime { get; set; }
        
        [MaxLength(4)]
        public int GodinaOsnivanja { get; set; }

        public string SedisteFirme { get; set; }
        
        [JsonIgnore]
        public IList<Automobil> ModeliAutomobila { get; set; }
    }
}