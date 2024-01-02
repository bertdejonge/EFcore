using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers {
    public class HuurContractMapper {
        public static Huurcontract MapToDomain(HuurcontractEF dataContract) {
            try {
                if (dataContract == null) {
                    return null;
                }
                return new Huurcontract(dataContract.HuurcontractID, 
                                        HuurperiodeMapper.MapToDomain(dataContract.Huurperiode), 
                                        HuurderMapper.MapToDomain(dataContract.Huurder),
                                        HuisMapper.MapToDomain(dataContract.Huis));
            } catch (Exception ex) {

                throw new MapperException("MapToDomain - MapHuurContract", ex);
            }
        }

        public static HuurcontractEF MapFromDomain(Huurcontract contract, ParkDbContext ctx) {
            try {
                HuisEF huisEF = ctx.Huizen.Find(contract.Huis.Id);
                if (huisEF == null) {
                    huisEF = HuisMapper.MapFromDomain(contract.Huis, ctx, contract.Huurder);
                }

                HuurderEF huurderEF = ctx.Huurders.Find(contract.Huurder.Id);
                if (huurderEF == null) {
                    huurderEF = HuurderMapper.MapFromDomain(contract.Huurder);
                }
                return new HuurcontractEF(contract.Id, HuurperiodeMapper.MapFromDomain(contract.Huurperiode), huurderEF, huisEF);
            } catch (Exception ex) {

                throw new MapperException("MapToDB - MapHuurContract", ex);
            }
        }
    }
}
