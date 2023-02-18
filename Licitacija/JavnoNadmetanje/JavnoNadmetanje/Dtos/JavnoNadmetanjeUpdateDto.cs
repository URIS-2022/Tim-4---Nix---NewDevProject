using System;
using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanje.Dtos
{
    /// <summary>
    /// klasa koja sadrzi samo elemente koje je dozvoljeno azurirati i menjati kada se definise javno nadmetanje
    /// </summary>
    public class JavnoNadmetanjeUpdateDto
    {
        #pragma warning disable CS1591 //nepotreban XML koment

        [Required]
        public Guid JavnoNadmetanjeID { get; set; }
        [Required]
        public DateTime DatumNadmetanja { get; set; }
        [Required]
        public DateTime VremePocetka { get; set; }
        [Required]
        public DateTime VremeKraja { get; set; }

        #pragma warning restore CS1591 //nepotreban XML koment
    }
}
