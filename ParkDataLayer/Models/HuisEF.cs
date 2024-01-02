using ParkBusinessLayer.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkDataLayer.Models {
    public class HuisEF {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HuisID { get; set; }

        [Column(TypeName = "NVARCHAR(250)")]
        public string Straat { get; set; }

        [Required]
        public int Nummer { get; set; }

        [Required]
        public bool Actief { get; set; }

        public string ParkID { get; set; }
        public ParkEF Park { get; set; }

        public List<HuurcontractEF> HuurContracten { get; set; } = new();

        public HuisEF() {

        }

        public HuisEF(int huisId, string straat, int nummer, bool actief, string parkId, ParkEF park, List<HuurcontractEF> huurContracten) {
            HuisID = huisId;
            Straat = straat;
            Nummer = nummer;
            Actief = actief;
            ParkID = parkId;
            Park = park;
            HuurContracten = huurContracten;
        }

        public HuisEF(string straat, int nummer, bool actief) {
            Straat = straat;
            Nummer = nummer;
            Actief = actief;
        }

        public HuisEF(int huisId, string straat, int nummer, bool actief, string parkId, ParkEF park) {
            HuisID = huisId;
            Straat = straat;
            Nummer = nummer;
            Actief = actief;
            ParkID = parkId;
            Park = park;
        }
    }
}