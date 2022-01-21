using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{

    [Table("Automobil")]
    public class Automobil
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }
        public string Boja { get; set; }

        [MaxLength(4)]
        [Range(1900,2022)]
        public int GodinaProizvodnje { get; set; }

        [Required]
        public int Cena { get; set; }
        public int Kubikaza { get; set; }
        public int BrojVrata { get; set; }
        public int Kolicina { get; set; }
        public string Karoserija { get; set; }
        public string Gorivo { get; set; }
        public int SnagaMotora { get; set; }


        [Required]
        [JsonIgnore]
        public int AutoPartnerID { get; set; }
    }
}