using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using ParkDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers {
    public class HuurderMapper {
        public static Huurder MapToDomain(HuurderEF dataHuurder) {
            try {
                return new Huurder(dataHuurder.HuurderID, dataHuurder.Naam, new Contactgegevens(dataHuurder.Email, 
                                                                                                dataHuurder.PhoneNumber, 
                                                                                                dataHuurder.Address));
            } catch (Exception ex) {
                throw new MapperException("Fout in HuurderMapper, MapToDomain: ", ex);
            }
        }

        public static HuurderEF MapFromDomain(Huurder huurder) {
            try {
                return new HuurderEF(huurder.Id, huurder.Naam, huurder.Contactgegevens.Tel, huurder.Contactgegevens.Email, huurder.Contactgegevens.Adres);
            } catch (Exception ex) {
                throw new MapperException("Fout in HuurderMapper, MapFromDomain:", ex);
            }
        }
    }
}
