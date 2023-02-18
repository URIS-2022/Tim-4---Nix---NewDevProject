using Komisija.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Komisija.Data
{
    public class LicnostKomisijeRepository : ILicnostKomisijeRepository
    {
        private readonly KomisijaContext _context;
        private readonly IKomisijaRepository _komisijaRepository;

        public LicnostKomisijeRepository(KomisijaContext context, IKomisijaRepository komisijaRepository)
        {
            _context = context;
            _komisijaRepository = komisijaRepository;
        }
        public void CreateLicnostKomisije(LicnostKomisije licnostKomisije)
        {
            if(licnostKomisije == null)
            {
                throw new ArgumentNullException(nameof(licnostKomisije));
            }
            _context.LicnostiKomisije.Add(licnostKomisije);
        }

        public void DeleteLicnostKomisije(Guid id)
        {
            var licnostKomsije = GetLicnostKomisijeById(id);
            if (licnostKomsije != null)
            {
                _context.Remove(licnostKomsije);
            }
        }

        public IEnumerable<LicnostKomisije> GetAll()
        {
            return _context.LicnostiKomisije.ToList();
        }

        public LicnostKomisije GetLicnostKomisijeById(Guid id)
        {
            return _context.LicnostiKomisije.FirstOrDefault(lk => lk.licnostKomisijeId == id);
        }

        public LicnostKomisije GetPredsednikaKomisije(Guid komisijaId)
        {
            return _context.LicnostiKomisije.FirstOrDefault(lk => lk.funkcijaLicnostiKomisije.Equals("Predsednik") && lk.komisijaId == komisijaId);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateLicnostKomisije(LicnostKomisije komisija)
        {
            
        }

        
    }
}
