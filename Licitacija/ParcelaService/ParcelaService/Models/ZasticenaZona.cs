using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ParcelaService.Models
{
    /// <summary>
    /// Predstavlja realni entitet zasticene zone.
    /// </summary>
    public class ZasticenaZona
    {
        /// <summary>
        /// Id zasticene zone
        /// </summary>
        [Key]
        public Guid ZasticenaZonaId { get; set; }

        /// <summary>
        /// Broj zasticene zone
        /// </summary>
        [Required]
        public int BrojZasticeneZone { get; set; }

        /// <summary>
        /// Lista dozvoljenih radova
        /// </summary>
        [Required]
        public List<DozvoljeniRad> DozvoljeniRadovi { get; set; }
    }
}
