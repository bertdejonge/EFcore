using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class ContractenRepositoryEF : IContractenRepository
    {
        private readonly ParkDbContext _context;

        public ContractenRepositoryEF() {
            _context = new();
        }

        public void SaveAndClear() {
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public void AnnuleerContract(Huurcontract contract)
        {
            try {
                _context.HuurContracten.Remove(new HuurcontractEF() { HuurcontractID = contract.Id });
                SaveAndClear();
            } catch (Exception ex) {

                throw new RepositoryException("Fout bij het annuleren van een contract: ", ex);
            }
        }

        public Huurcontract GeefContract(string id)
        {
            try {
                HuurcontractEF dataContract = _context.HuurContracten.Where(h => h.HuurcontractID == id)
                                                                      .Include(h => h.Huis)
                                                                          .ThenInclude(h => h.Park)
                                                                      .Include(h => h.Huurperiode)
                                                                      .Include(h => h.Huurder)
                                                                       .AsNoTracking().FirstOrDefault();

                return HuurContractMapper.MapToDomain(dataContract);
            } catch (Exception ex) {

                throw new RepositoryException("Fout bij het ophalen van een contract: ", ex);
            }
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            try {
                if (dtEinde == null) {
                    return _context.HuurContracten.Include(h => h.Huis)
                                                        .ThenInclude(h => h.Park)
                                                   .Include(h => h.Huurperiode).Include(h => h.Huurder)
                                                   .Where(h => h.Huurperiode.StartDatum >= dtBegin)
                                                   .Select(h => HuurContractMapper.MapToDomain(h)).AsNoTracking().ToList();
                } else {
                    return _context.HuurContracten.Include(h => h.Huis)
                                                        .ThenInclude(h => h.Park)
                                                  .Include(h => h.Huurperiode)
                                                  .Include(h => h.Huurder)
                                                  .Where(h => h.Huurperiode.StartDatum >= dtBegin && h.Huurperiode.EindDatum <= dtEinde)
                                                  .Select(h => HuurContractMapper.MapToDomain(h)).AsNoTracking().ToList();
                }
                
            } catch (Exception ex) {

                throw new RepositoryException("Fout bij het ophalen van contracten: ", ex);
            }
        }

        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            try {
                return _context.HuurContracten.Any(h => h.Huurperiode.StartDatum == startDatum 
                                                    && h.Huurder.HuurderID == huurderid 
                                                    && h.Huis.HuisID == huisid);
            } catch (Exception ex) {

                throw new RepositoryException("Fout bij HeeftContract : ", ex);
            }
        }

        public bool HeeftContract(string id)
        {
            try {
                return _context.HuurContracten.Any(h => h.HuurcontractID == id);
            } catch (Exception ex) {

                throw new RepositoryException("Fout bij HeeftContract: ", ex);
            }
        }

        public void UpdateContract(Huurcontract contract)
        {
            try {
                _context.HuurContracten.Update(HuurContractMapper.MapFromDomain(contract, _context));
                SaveAndClear();
            } catch (Exception ex) {

                throw new RepositoryException("Fout bij UpdateContract ", ex);
            }
        }

        public void VoegContractToe(Huurcontract contract)
        {
            try {
                HuurcontractEF huurcontractEF = HuurContractMapper.MapFromDomain(contract, _context);
                _context.HuurContracten.Add(huurcontractEF);
                SaveAndClear();
            } catch (Exception ex) {

                throw new RepositoryException("Fout bij VoegContractToe: ", ex);
            }
        }
    }
}
