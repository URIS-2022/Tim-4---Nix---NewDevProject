using System;

namespace Ugovor.Dtos
{
    public class UgovorConfirmationDto
    {
        /// <summary>
        /// ID ugovora
        /// </summary>
        public Guid UgovorId { get; set; }

        /// <summary>
        /// ID kupca
        /// </summary>
        public Guid LiceId { get; set; }
    }
}
