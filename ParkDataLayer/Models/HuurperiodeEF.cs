using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model {
    public class HuurperiodeEF {
        [Key]
        public int HuurperiodeID { get; set; }
        [Required]
        public DateTime StartDatum { get; set; }
        [Required]
        public DateTime EindDatum { get; set; }
        [Required]
        public int Aantaldagen { get; set; }

        public HuurperiodeEF() {

        }

        public HuurperiodeEF(int huurperiodeId, DateTime startDatum, DateTime eindDatum) {
            HuurperiodeID = huurperiodeId;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            Aantaldagen = (eindDatum.Date - StartDatum.Date).Days;
        }

        public HuurperiodeEF(DateTime startDatum, DateTime eindDatum) {
            StartDatum = startDatum;
            EindDatum = eindDatum;
            Aantaldagen = (eindDatum.Date - StartDatum.Date).Days;
        }

        public HuurperiodeEF(DateTime startDatum, int aantaldagen) {
            StartDatum = startDatum;
            Aantaldagen = aantaldagen;
            EindDatum = startDatum.AddDays(aantaldagen);
        }

        public HuurperiodeEF(int huurperiodeId, DateTime startDatum, int aantaldagen) {
            HuurperiodeID = huurperiodeId;
            StartDatum = startDatum;
            Aantaldagen = aantaldagen;
            EindDatum = startDatum.AddDays(aantaldagen);
        }
    }
}
