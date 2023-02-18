using JavnoNadmetanje.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanje.Models
{
    /// <summary>
    /// klasa u kojoj modelujemo javno nadmetanje
    /// </summary>
    public class JavnoNadmetanjeModel
    {
        //ukljucuje sve sa key i required anotacijama

        /// <summary>
        /// primarni kljuc/id javnog nadmetanja 
        /// </summary>
        [Key]
        public Guid JavnoNadmetanjeID { get; set; }

        /// <summary>
        /// datum dana kada se desava javno nadmetanje
        /// </summary>
        [Required]
        public DateTime DatumNadmetanja { get; set; }

        /// <summary>
        /// datum i vreme pocetka javnog nadmetnaja
        /// </summary>
        [Required]
        public DateTime VremePocetka { get; set; }

        /// <summary>
        /// datum i vreme kraja javnog nadmetnaja
        /// </summary>
        [Required]
        public DateTime VremeKraja { get; set; }

        /// <summary>
        /// ako je ovaj bool:
        /// 1. true - javno nadmetanje je otkazano
        /// 2. false - javno nadmetanje ce se odrzati po planu
        /// </summary>
        [Required]
        public bool Izuzeto { get; set; }

        /// <summary>
        /// celobrojna vrednost predlozene pocetne cene po hektaru na javnom nadmetanju
        /// </summary>
        [Required]
        public int PocetnaCenaPoHektaru { get; set; }

        /// <summary>
        /// celobrojna vrednost izlicitirane cene za odredju parcelu za koju se vrsi javno nadmetanje
        /// </summary>
        [Required]
        public int IzlicitiranaCena { get; set; }

        /// <summary>
        /// oznacava na koliko dugo se zakupljuje parcela (1 godina, 2 godine...)
        /// </summary>
        [Required]
        public int PeriodZakupa { get; set; }

        /// <summary>
        /// broj ucesnika koji ucestvuje na javnom nadmetanju
        /// </summary>
        [Required]
        public int BrojUcesnika { get; set; }

        /// <summary>
        /// visina dopune depozita (ako postoji)
        /// </summary>
        [Required]
        public int VisinaDopuneDepozita { get; set; }

        /// <summary>
        /// krug ili etapa javnog nadmetanja
        /// ako je prvi krug neuspesan, onda se otvara 2. krug nadmetanja
        /// </summary>
        [Required]
        public int Krug { get; set; }

        /// <summary>
        /// odabir tipa javnog nadmetanja
        /// </summary>
        [Required]
        public TipJavnogNadmetanja Tip { get; set; }

        /// <summary>
        /// odabir statusa javnog nadmetanja
        /// </summary>
        [Required]
        public StatusJavnogNadmetanja Status { get; set; }

        /// <summary>
        /// odabir katastarkse opstine u kojoj se nalazi parcela 
        /// </summary>
        [Required]
        public KatastarskeOpstine KatastarskaOpstina { get; set; }
        
        /// <summary>
        /// strani kljuc koji naznacaju na entite kupac
        /// </summary>
        [Required]
        public Guid KupacID { get; set; }

        /// <summary>
        /// strani kljuc koji naznacaju na tabelu adresa
        /// </summary>
        [Required]
        public Guid AdresaID { get; set; }

        /// <summary>
        /// broj prijavljenih ljudi za javno nadmetanje
        /// </summary>
        [Required]
        public int PrijavljeniKupci { get; set; }

        /// <summary>
        /// strani kljuc koji naznacaju na tabelu licitacija
        /// </summary>
        [Required]
        public Guid LicitacijaID { get; set; }

        /// <summary>
        /// strani kljuc koji naznacava na tabelu parcela
        /// </summary>
        [Required]
        public Guid ParcelaID { get; set; }
    }
}
