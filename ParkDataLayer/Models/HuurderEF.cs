using ParkBusinessLayer.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkDataLayer.Models {
    public class HuurderEF {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HuurderID { get; set; }

        [Required, Column(TypeName = "NVARCHAR(100)")]
        public string Naam { get; set; }

        public string PhoneNumber { get; set; } 
        public string Email { get; set; }
        public string Address { get; set; }

        public HuurderEF() {

        }

        public HuurderEF(int huurderID, string naam, string phoneNumber, string email, string address) {
            HuurderID = huurderID;
            Naam = naam;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }

        public HuurderEF(string naam, string phoneNumber, string email, string address) {
            Naam = naam;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }
    }
}