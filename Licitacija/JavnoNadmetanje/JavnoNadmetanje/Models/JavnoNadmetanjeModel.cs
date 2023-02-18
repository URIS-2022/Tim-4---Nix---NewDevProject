using JavnoNadmetanje.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanje.Models
{
    public class JavnoNadmetanjeModel
    {
        //ukljucuje sve sa key i required anotacijama

        //primarni kljuc
        [Key]
        public Guid JavnoNadmetanjeID { get; set; }

        //osnovni podaci
        [Required]
        public DateTime DatumNadmetanja { get; set; }
        [Required]
        public DateTime VremePocetka { get; set; }
        [Required]
        public DateTime VremeKraja { get; set; }
        [Required]
        public bool Izuzeto { get; set; }
        [Required]
        public int PocetnaCenaPoHektaru { get; set; }
        [Required]
        public int IzlicitiranaCena { get; set; }
        [Required]
        public int PeriodZakupa { get; set; }
        [Required]
        public int BrojUcesnika { get; set; }
        [Required]
        public int VisinaDopuneDepozita { get; set; }
        [Required]
        public int Krug { get; set; }
        [Required]

        //izbori
        public TipJavnogNadmetanja Tip { get; set; }
        [Required]
        public StatusJavnogNadmetanja Status { get; set; }
        [Required]
        public KatastarskeOpstine KatastarskaOpstina { get; set; }
        [Required]

        //strani kljucevi
        public Guid KupacID { get; set; }
        [Required]
        public Guid AdresaID { get; set; }
        [Required]
        public int PrijavljeniKupci { get; set; }
        [Required]
        public Guid LicitacijaID { get; set; }
        [Required]
        public Guid ParcelaID { get; set; }
    }
}
