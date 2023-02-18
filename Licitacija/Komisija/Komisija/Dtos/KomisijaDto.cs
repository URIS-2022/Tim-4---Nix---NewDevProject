using Komisija.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Komisija.Dtos
{
    public class KomisijaDto
    {
        
        public Guid komisijaId { get; set; }

        public String nazivKomisije { get; set; }

        public String oznakaKomisije { get; set; }

        public LicnostKomisije predsednikKomisije { get; set; }

        public ICollection<LicnostKomisije> clanoviKomisije { get; set; }
    }
}
