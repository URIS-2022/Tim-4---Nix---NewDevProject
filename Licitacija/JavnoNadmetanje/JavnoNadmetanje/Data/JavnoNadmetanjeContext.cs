using JavnoNadmetanje.Enums;
using JavnoNadmetanje.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace JavnoNadmetanje.Data
{
    /// <summary>
    /// klasa za definisanje konteksta javnog nadmetanja 
    /// </summary>
    public class JavnoNadmetanjeContext : DbContext
    {
        /// <summary>
        /// ovde ne upisujemo nista
        /// </summary>
        /// <param name="options"></param>
        public JavnoNadmetanjeContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// setovanje i uzimanje baze sa definisanim modelom javnog nadmetanja
        /// </summary>
        public DbSet<JavnoNadmetanjeModel> JavnaNadmetanja { get; set; }

    }
}
