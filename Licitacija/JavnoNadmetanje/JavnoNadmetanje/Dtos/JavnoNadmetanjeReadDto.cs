using JavnoNadmetanje.Enums;
using System;

namespace JavnoNadmetanje.Dtos
{
    public class JavnoNadmetanjeReadDto
    {
        //isto kao model samo bez key i required anotacija

        //primarni kljuc
        public Guid JavnoNadmetanjeID { get; set; }

        //osnovni podaci
        public DateTime DatumNadmetanja { get; set; }
        public DateTime VremePocetka { get; set; }
        public DateTime VremeKraja { get; set; }
        public bool Izuzeto { get; set; }
        public int PocetnaCenaPoHektaru { get; set; }
        public int IzlicitiranaCena { get; set; }
        public int PeriodZakupa { get; set; }
        public int BrojUcesnika { get; set; }
        public int VisinaDopuneDepozita { get; set; }
        public int Krug { get; set; }

        //izbori
        public TipJavnogNadmetanja Tip { get; set; }
        public StatusJavnogNadmetanja Status { get; set; }
        public KatastarskeOpstine KatastarskaOpstina { get; set; }

        //strani kljucevi
        //public Guid KupacID { get; set; }
        //public Guid AdresaID { get; set; }
        public int PrijavljeniKupci { get; set; }
        //public Guid LicitantID { get; set; }
        //public Guid ParcelaID { get; set; }
  
    }
}
