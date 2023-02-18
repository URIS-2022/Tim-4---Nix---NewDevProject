using Komisija.Models;
using System.Collections.Generic;
using System;

namespace Komisija.Data
{
    public interface ILicnostKomisijeRepository
    {
        IEnumerable<LicnostKomisije> GetAll();
        LicnostKomisije GetLicnostKomisijeById(Guid id);
        LicnostKomisije GetPredsednikaKomisije(Guid komisijaId);
        void CreateLicnostKomisije(LicnostKomisije licnostKomisije);
        void UpdateLicnostKomisije(LicnostKomisije komisija);
        void DeleteLicnostKomisije(Guid id);
        bool SaveChanges();
    }
}
