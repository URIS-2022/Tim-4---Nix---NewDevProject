﻿using Korisnici.Entities;

namespace Korisnici.Models.Korisnik
{
    /// <summary>
    /// Predstavlja model korisnika prilikom kreiranja
    /// </summary>
    public class KorisnikDTOCreate
    {
        /// <summary>
        /// Ime korisnika
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime korisnika
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Korisnicko ime korisnika
        /// </summary>
        public string KorisnickoIme { get; set; }

        /// <summary>
        /// Lozinka korisnika
        /// </summary>
        public string Lozinka { get; set; }

        /// <summary>
        /// Naziv tipa korisnika(Operater, Superuser...)
        /// </summary>

        public TipKorisnika TipKorisnika { get; set; }
    }
}
