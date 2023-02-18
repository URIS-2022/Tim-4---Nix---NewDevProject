using System.Collections.Generic;
using System;
using KupacService.Entities;
using KupacService.Models.Kupac;
using KupacService.Models.BrojTable;
using KupacService.Entities.Enumeration;

namespace KupacService.Models.OvlascenoLice
{
    /// <summary>
    /// DTO za ovlašćeno lice
    /// </summary>
    public class OvlascenoLiceDTO
    {
        /// <summary>
        /// Identifikaciona oznaka ovlašćenog lica.
        /// </summary>
        public Guid OvlascenoLiceID { get; set; }

        /// <summary>
        /// Da li je ovlašćeno lice strani državljanin ili ne.
        /// </summary>
        public TipOvlascenogLica? TipOvlascenogLica { get; set; }

        /// <summary>
        /// Ime ovlašćenog lica.
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime ovlašćenog lica.
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Adresa ovlašćenog lica.
        /// </summary>
        public string Adresa { get; set; }

        /// <summary>
        /// Kupci u čije ime ovlašćeno lice učestvuje na nadmetanjima.
        /// </summary>
        public ICollection<KupacDTO> Kupci { get; set; }

        /// <summary>
        /// Brojevi tabla javnih nadmetanja na kojima ovlašćeno lice učestvuje.
        /// </summary>
        public ICollection<BrojTableDTO> BrojeviTabla { get; set; }
    }
}
