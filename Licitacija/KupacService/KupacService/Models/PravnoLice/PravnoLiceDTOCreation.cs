﻿using KupacService.Models.Kupac;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KupacService.Models.PravnoLice
{
    /// <summary>
    /// Kreiranje DTO
    /// </summary>
    public class PravnoLiceDTOCreation : KupacDTOCreation,IValidatableObject
    {
        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        [MaxLength(40)]
        public string Naziv { get; set; }

        /// <summary>
        /// Matični broj pravnog lica (kao JMBG za fizičko lice)
        /// </summary>
        [Required,MaxLength(8)]
        public string MaticniBroj { get; set; }

        /// <summary>
        /// Kontakt osoba pravnog lica
        /// </summary>
        public Guid KontaktOsobaID { get; set; }

        /// <summary>
        /// Faks informacije
        /// </summary>
        public string Faks { get; set; }

        public new IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(MaticniBroj, @"^\d+$"))
            {
                yield return new ValidationResult(
                    "Za vrednost polja MaticniBroj nije dozvoljen unos karaktera koji nisu brojevi.",
                    new[] { "PravnoLiceDTOCreation" });
            }
        }
    }
}
