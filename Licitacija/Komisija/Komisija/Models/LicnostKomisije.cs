using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Komisija.Models
{
    public class LicnostKomisije
    {
        [Key]
        [Required]
        public Guid licnostKomisijeId { get; set; }

        [StringLength(50)]
        [Required]
        public string imeLicnostiKomisije { get; set; }

        [StringLength(50)]
        [Required]
        public string prezimeLicnostiKomisije { get; set; }

        [StringLength(50)]
        [Required]
        public string funkcijaLicnostiKomisije { get; set; }

        [Phone]
        [Required]
        public string kontaktLicnostiKomisije { get; set; }

        [Required]
        public DateTime datumRodjenjaLicnostiKomisije { get; set; }

        [ForeignKey("komisijaId")]
        public Guid komisijaId { get; set; }
        public String oznakaKomisije { get; set; }

    }
}
