using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Models;
using System;
using System.Linq;

namespace ParkDataLayer.Mappers {
    public class ParkMapper {
        public static Park MapToDomain(ParkEF dataPark) {
            try {
                return new Park(dataPark.ParkID, dataPark.Naam, dataPark.Locatie);
            } catch (Exception ex) {
                throw new MapperException("Fout in Parkmapper: MapToDomain: ", ex);
            }
        }

        public static ParkEF MapFromDomain(Park park, ParkDbContext context) {
            try {
                return new ParkEF(park.Id, park.Naam, park.Locatie, park.Huizen().Select(h => HuisMapper.MapFromDomain(h, context)).ToList());
            } catch (Exception ex) {
                throw new MapperException("MapPark - MapToDB", ex);
            }
        }
    }
}