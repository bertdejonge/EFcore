using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace ParkDataLayer.Repositories
{
    public class HuurderRepositoryEF : IHuurderRepository
    {
        private readonly ParkDbContext _context;

        public HuurderRepositoryEF() {
            _context = new();
        }

        private void SaveAndClear() {
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public Huurder GeefHuurder(int id)
        {
            try {
                HuurderEF huurderEF = _context.Huurders.AsNoTracking().FirstOrDefault(h => h.HuurderID == id);
                return HuurderMapper.MapToDomain(huurderEF);
            } catch (Exception ex) {

                throw new RepositoryException("Fout in GeefHuurder: ", ex);
            }
        }

        public List<Huurder> GeefHuurders(string naam)
        {
            try {
                List<HuurderEF> huurdersEF = _context.Huurders.AsNoTracking().Where(h => h.Naam.ToLower() == naam.ToLower()).ToList();
                return huurdersEF.Select(h => HuurderMapper.MapToDomain(h)).ToList();
            } catch (Exception ex) {

                throw new RepositoryException("Fout in GeefHuurders - ", ex);
            }
        }

        public bool HeeftHuurder(string naam, Contactgegevens contact)
        {
            try {
                return _context.Huurders.Any(h => h.Naam == naam && h.Address == contact.Adres 
                                                                 && h.Email == contact.Email 
                                                                 && h.PhoneNumber == contact.Tel );
            } catch (Exception ex) {

                throw new RepositoryException("Fout in HeeftHuurder (naam & contact): ", ex);
            }
        }

        public bool HeeftHuurder(int id)
        {
            try {
                return _context.Huurders.Any(h => h.HuurderID == id);
            } catch (Exception ex) {

                throw new RepositoryException("Fout in HeeftHuurder (ID): ", ex);
            }
        }

        public void UpdateHuurder(Huurder huurder)
        {
            try {
                _context.Huurders.Update(HuurderMapper.MapFromDomain(huurder));
                SaveAndClear();
            } catch (Exception ex) {

                throw new RepositoryException("Fout in UpdateHuurder  ", ex);
            }
        }

        public Huurder VoegHuurderToe(Huurder h)
        {
            try {
                _context.Huurders.Add(HuurderMapper.MapFromDomain(h));
                SaveAndClear();
                return h;
            } catch (Exception ex) {

                throw new RepositoryException("Fout in VoegHuurderToe ", ex);
            }
        }
    }
}
