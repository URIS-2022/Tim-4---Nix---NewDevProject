using System.Collections.Generic;
using System;
using Komisija.Models;

namespace Komisija.Data
{
    public interface IKomisijaRepository
    {
        IEnumerable<KomisijaModel> GetAll();
        KomisijaModel GetKomisijaById(Guid id);
        KomisijaModel GetKomisjaByOznaka(String oznakaKomisije);
        void CreateKomisija(KomisijaModel komisija);
        void UpdateKomisija(KomisijaModel komisija);
        void DeleteKomsija(Guid id);
        bool SaveChanges();
    }
}
