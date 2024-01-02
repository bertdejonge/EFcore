using ParkBusinessLayer.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ParkDataLayer.Model;

namespace ParkDataLayer.Models {
    public class HuurcontractEF {
        [Key]
        [Column(TypeName = "NVARCHAR(25)")]
        public string HuurcontractID { get; set; }

        public int HuurperiodeID { get; set; }

        [Required]
        public HuurperiodeEF Huurperiode { get; set; }

        public HuurderEF Huurder { get; set; }
        public HuisEF Huis { get; set; }
        public HuurcontractEF() {
        }

        public HuurcontractEF(string huurcontractId, HuurperiodeEF huurperiode, HuurderEF huurder, HuisEF huis) {
            HuurcontractID = huurcontractId;
            Huurperiode = huurperiode;
            Huurder = huurder;
            Huis = huis;
        }

        public HuurcontractEF(string huurcontractId, int huurperiodeId, HuurperiodeEF huurperiode, HuurderEF huurder, HuisEF huis) {
            HuurcontractID = huurcontractId;
            HuurperiodeID = huurperiodeId;
            Huurperiode = huurperiode;
            Huurder = huurder;
            Huis = huis;
        }
    }
}