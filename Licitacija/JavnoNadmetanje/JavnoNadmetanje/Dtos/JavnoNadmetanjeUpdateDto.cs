using JavnoNadmetanje.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanje.Dtos
{
    public class JavnoNadmetanjeUpdateDto
    {
        [Required]
        public Guid JavnoNadmetanjeID { get; set; }
        [Required]
        public DateTime DatumNadmetanja { get; set; }
        [Required]
        public DateTime VremePocetka { get; set; }
        [Required]
        public DateTime VremeKraja { get; set; }
    }
}
