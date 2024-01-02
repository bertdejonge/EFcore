using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Models;
using System;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuizenRepositoryEF : IHuizenRepository
    {
        private readonly ParkDbContext _context;

        public HuizenRepositoryEF() {
            _context = new();
        }

        private void SaveAndClear() {
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public Huis GeefHuis(int id)
        {
            try {
                HuisEF dataHuis = _context.Huizen.Include(h => h.Park)
                                                 .Where(h => h.HuisID == id)
                                                 .AsNoTracking().FirstOrDefault();

                return HuisMapper.MapToDomain(dataHuis);
            } catch (Exception ex) {

                throw new RepositoryException("Fout in GeefHuis: ", ex);
            }
        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            try {
                return _context.Huizen.Any(h => h.Straat == straat && h.Nummer == nummer && h.Park == ParkMapper.MapFromDomain(park, _context));

            } catch (Exception ex) {

                throw new RepositoryException("Error in HeeftHuis: ", ex);
            }
        }

        public bool HeeftHuis(int id)
        {
            try {
                return _context.Huizen.Any(h => h.HuisID == id);
            } catch (Exception ex) {

                throw new RepositoryException("Error in HeeftHuis: ", ex);
            }
        }

        public void UpdateHuis(Huis huis)
        {
            try {
                _context.Huizen.Update(HuisMapper.MapFromDomain(huis, _context));
                SaveAndClear();
            } catch (Exception ex) {

                throw new RepositoryException("UpdateHuis - ", ex);
            }
        }

        public Huis VoegHuisToe(Huis h)
        {
            try {
                HuisEF huisEF = HuisMapper.MapFromDomain(h, _context);
                _context.Huizen.Add(huisEF);
                SaveAndClear();
                h.ZetId(huisEF.HuisID);
                return h;
            } catch (Exception ex) {

                throw new RepositoryException("VoegHuisToe - ", ex);
            }
        }
    }
}
