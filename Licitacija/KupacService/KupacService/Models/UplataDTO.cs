using KupacService.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacService.Models
{
    /// <summary>
    /// Uplata DTO
    /// </summary>
    public class UplataDTO
    {
        /// <summary>
        /// ID Uplate kupca.
        /// </summary>
        public Guid? UplataID { get; set; }

    }
}
