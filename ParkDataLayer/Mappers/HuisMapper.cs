using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers {
    public class HuisMapper {
        public static Huis MapToDomain(HuisEF dataHuis) {
            try {
                if(dataHuis == null) {
                    return null;
                }
                if (dataHuis.HuurContracten.Count == 0) {
                    return new Huis(dataHuis.HuisID, 
                                    dataHuis.Straat, 
                                    dataHuis.Nummer, 
                                    dataHuis.Actief, 
                                    ParkMapper.MapToDomain(dataHuis.Park));
                }
                return new Huis(dataHuis.HuisID, 
                                dataHuis.Straat, 
                                dataHuis.Nummer, 
                                dataHuis.Actief, 
                                ParkMapper.MapToDomain(dataHuis.Park));

            } catch (Exception ex) {

                throw new MapperException("Fout in HuisMapper, MapToDomain: ", ex);
            }
        }

        public static HuisEF MapFromDomain(Huis huis, ParkDbContext ctx, Huurder huurder = null) {
            try {
                ParkEF parkEF = ctx.Parken.Find(huis.Park.Id);
                if (parkEF == null) {
                    parkEF = ParkMapper.MapFromDomain(huis.Park, ctx);
                }

                if(huurder  != null) {
                    return new HuisEF(huis.Id, huis.Straat, huis.Nr, huis.Actief, parkEF.ParkID, parkEF, huis.Huurcontracten(huurder).Select(h => HuurContractMapper.MapFromDomain(h, ctx)).ToList());
                } else {
                    return new HuisEF(huis.Id, huis.Straat, huis.Nr, huis.Actief, parkEF.ParkID, parkEF);
                }

            } catch (Exception ex) {
                throw new MapperException("MapHuis - MapToDB", ex);
            }
        }
    }
}
