using KupacService.Data.Context;
using KupacService.Data.Interfaces;
using KupacService.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KupacService.Data.Repositories
{
    /// <summary>
    /// Kupac repozitorijum 
    /// </summary>
    public class KupacRepository : IKupacRepository
    {
        private readonly KupacDBContext _context;

        /// <summary>
        /// Konstruktor 
        /// </summary>
        /// <param name="context"></param>
        public KupacRepository(KupacDBContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Post metoda - definicija
        /// </summary>
        /// <param name="kupac"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CreateKupac(Kupac kupac)
        {
            if(kupac == null)
            {
                throw new ArgumentNullException(nameof(kupac));
            }

            _context.Kupci.Add(kupac);
        }

        /// <summary>
        /// Delete metoda - definicija
        /// </summary>
        /// <param name="kupacID"></param>
        /// <exception cref="ArgumentException"></exception>
        public void DeleteKupac(Guid kupacID)
        {
            var Kupac = _context.Kupci.Find(kupacID);
            if (Kupac == null)
            {
                throw new ArgumentException($"Kupac sa ID-jem {kupacID} nije pronađen.");
            }

            _context.Kupci.Remove(Kupac);

        }

        /// <summary>
        /// Get all - definicija
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Kupac> GetAllKupci()
        {
            return _context.Kupci.ToList();
        }

        /// <summary>
        /// Get By ID - definicija
        /// </summary>
        /// <param name="kupacID"></param>
        /// <returns></returns>
        public Kupac GetKupacByID(Guid kupacID)
        {
            return _context.Kupci.FirstOrDefault(p => p.KupacID == kupacID);
        }

        /// <summary>
        /// Put metoda - definicija
        /// </summary>
        /// <param name="kupac"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateKupac(Kupac kupac)
        {
            if (kupac == null)
            {
                throw new ArgumentNullException(nameof(kupac));
            }

            _context.Kupci.Update(kupac);
        }

        /// <summary>
        /// Save metoda
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
