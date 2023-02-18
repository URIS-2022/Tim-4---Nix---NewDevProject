using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Komisija.Models
{
    public class KomisijaModel
    {

        [Key]
        [Required]
        public Guid komisijaId { get; set; }

        [StringLength(50)]
        [Required]
        public String nazivKomisije { get; set; }

        [Required]
        public String oznakaKomisije { get; set; }

        [NotMapped]
        public LicnostKomisije predsednikKomisije { get; set; }

        [NotMapped]
        public ICollection<LicnostKomisije> clanoviKomisije { get; set; }
    }
}
