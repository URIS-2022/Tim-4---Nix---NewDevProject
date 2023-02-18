using JavnoNadmetanje.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanje.Dtos
{
    /// <summary>
    /// klasa javnog nadmetanja koju koristimo za kreiranje novog javnog nadmetanja
    /// </summary>
    public class JavnoNadmetanjeCreateDto
    {
        #pragma warning disable CS1591 //nepotreban XML koment

        //isto kao model samo bez ID-a 

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
        public TipJavnogNadmetanja Tip { get; set; }
        [Required]
        public StatusJavnogNadmetanja Status { get; set; }
        [Required]
        public KatastarskeOpstine KatastarskaOpstina { get; set; }
        //[Required]
        //public Guid KupacID { get; set; }
        //[Required]
        //public Guid AdresaID { get; set; }
        [Required]
        public int PrijavljeniKupci { get; set; }
        //[Required]
        //public Guid LicitantID { get; set; }
        //[Required]
        //public Guid ParcelaID { get; set; }

        #pragma warning restore CS1591 //nepotreban XML koment

    }
}
