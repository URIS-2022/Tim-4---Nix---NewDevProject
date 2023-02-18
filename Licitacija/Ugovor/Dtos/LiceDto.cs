using System;

namespace Ugovor.Dtos
{
    public class LiceDto
    {
        /// <summary>
        /// Id lica- kupca
        /// </summary>
        public Guid KupacId { get; set; }
        /// <summary>
        /// Ostvarena povrsina
        /// </summary>
        public int OstvarenaPovrsina { get; set; }
        /// <summary>
        /// Da li ima zabranu
        /// </summary>
        public bool ImaZabranu { get; set; }
    }
}
