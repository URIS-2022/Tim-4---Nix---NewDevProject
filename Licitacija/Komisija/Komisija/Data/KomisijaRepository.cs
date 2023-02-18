using Komisija.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Komisija.Data
{
    public class KomisijaRepository : IKomisijaRepository

    {
        private readonly KomisijaContext _context;

        public KomisijaRepository(KomisijaContext context)
        {
            _context = context;
        }
        public void CreateKomisija(KomisijaModel komisija)
        {
            if (komisija == null) throw new ArgumentNullException(nameof(komisija));

            _context.Komisije.Add(komisija);
        }

        public void DeleteKomsija(Guid id)
        {
            var komisija = GetKomisijaById(id);
            if (komisija != null)
            {
                _context.Remove(komisija);
            }
        }

        public IEnumerable<KomisijaModel> GetAll()
        {
            return _context.Komisije.ToList();
        }

        public KomisijaModel GetKomisijaById(Guid id)
        {
            return _context.Komisije.FirstOrDefault(k => k.komisijaId == id);
        }

        public KomisijaModel GetKomisjaByOznaka(string oznakaKomisije)
        {
            return _context.Komisije.FirstOrDefault(k => k.oznakaKomisije.Equals(oznakaKomisije));
        }


        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateKomisija(KomisijaModel komisija)
        {
            //nije potrebna implementacija
        }
    }
}
