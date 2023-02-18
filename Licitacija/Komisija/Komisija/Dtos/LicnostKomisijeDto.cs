using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Komisija.Dtos
{
    public class LicnostKomisijeDto
    {
        public Guid licnostKomisijeId { get; set; }

        public string imeLicnostiKomisije { get; set; }

        public string prezimeLicnostiKomisije { get; set; }

        public string funkcijaLicnostiKomisije { get; set; }

        public string kontaktLicnostiKomisije { get; set; }

        public DateTime datumRodjenjaLicnostiKomisije { get; set; }

        public Guid komisijaId { get; set; }
        public String oznakaKomisije { get; set; }
    }
}
