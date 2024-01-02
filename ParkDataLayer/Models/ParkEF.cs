using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Models {
    public class ParkEF {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(20)] 
        public string ParkID { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(250)")]
        public string Naam { get; set; }

        [Column(TypeName = "NVARCHAR(500)")]
        public string Locatie { get; set; }

        public List<HuisEF> Huis { get; set; }

        public ParkEF() {

        }

        public ParkEF(string parkId, string naam, string locatie, List<HuisEF> huis) {
            ParkID = parkId;
            Naam = naam;
            Locatie = locatie;
            Huis = huis;
        }

        public ParkEF(string parkId, string naam, string locatie) {
            ParkID = parkId;
            Naam = naam;
            Locatie = locatie;
        }
    }
}
