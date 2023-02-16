using System;

namespace KatastarskaOpstinaService.DTOs.CreationDto
{
    public class StatutOpstineCreationDto
    {
        /// <summary>
        /// Sadrzaj statuta opstine
        /// </summary>
        public string SadrzajStatuta { get; set; }

        /// <summary>
        /// Datum kreiranja statuta opstine
        /// </summary>
        public DateTime DatumKreiranjaStatuta { get; set; }
    }
}
