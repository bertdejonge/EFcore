using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;

namespace ParkDataLayer.Mappers {
    public class HuurperiodeMapper {
        public static Huurperiode MapToDomain(HuurperiodeEF dataHuur) {
            try {
                return new Huurperiode(dataHuur.StartDatum, dataHuur.Aantaldagen);
            } catch (Exception ex) {
                throw new MapperException("Fout in HuurperiodeMapper, MapToDomain: ", ex);
            }
        }

        public static HuurperiodeEF MapFromDomain(Huurperiode huurperiode) {
            try {
                return new HuurperiodeEF(huurperiode.StartDatum, huurperiode.EindDatum);
            } catch (Exception ex) {
                throw new MapperException("Fout in HuurperiodeMapper, MapFromDomain:", ex);
            }
        }
    }
}