using KupacService.Data.Context;
using KupacService.Data.Interfaces;
using KupacService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KupacService.Data.Repositories
{
    /// <summary>
    /// Ovlasceno lice repozitorijum 
    /// </summary>
    public class OvlascenoLiceRepository : IOvlascenoLiceRepository
    {
        private readonly KupacDBContext _context;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="context"></param>
        public OvlascenoLiceRepository(KupacDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Post metoda - definicija
        /// </summary>
        /// <param name="ovlascenoLice"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CreateOvlascenoLice(OvlascenoLice ovlascenoLice)
        {
            if (ovlascenoLice == null)
            {
                throw new ArgumentNullException(nameof(ovlascenoLice));
            }

            _context.OvlascenaLica.Add(ovlascenoLice);
        }

        /// <summary>
        /// Delete metoda - definicija
        /// </summary>
        /// <param name="ovlascenoLiceID"></param>
        /// <exception cref="ArgumentException"></exception>
        public void DeleteOvlascenoLice(Guid ovlascenoLiceID)
        {
            var OvlascenoLice = _context.OvlascenaLica.Find(ovlascenoLiceID);
            if (OvlascenoLice == null)
            {
                throw new ArgumentException($"Ovlašćeno lice sa ID-jem {ovlascenoLiceID} nije pronađen.");
            }

            _context.OvlascenaLica.Remove(OvlascenoLice);
        }

        /// <summary>
        /// Get All - definicija
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OvlascenoLice> GetAllOvlascenaLica()
        {
            return _context.OvlascenaLica.ToList();
        }

        /// <summary>
        /// Get By ID - definicija
        /// </summary>
        /// <param name="ovlascenoLiceID"></param>
        /// <returns></returns>
        public OvlascenoLice GetOvlascenoLiceByID(Guid ovlascenoLiceID)
        {
            return _context.OvlascenaLica.FirstOrDefault(p => p.OvlascenoLiceID == ovlascenoLiceID);
        }

        /// <summary>
        /// Save metoda
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        /// <summary>
        /// Put metoda - definicija
        /// </summary>
        /// <param name="ovlascenoLice"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateOvlascenoLice(OvlascenoLice ovlascenoLice)
        {
            if (ovlascenoLice == null)
            {
                throw new ArgumentNullException(nameof(ovlascenoLice));
            }

            _context.OvlascenaLica.Update(ovlascenoLice);
        }
    }
}
