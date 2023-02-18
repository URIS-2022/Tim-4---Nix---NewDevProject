using Komisija.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Komisija.Data
{
    public class KomisijaContext :DbContext
    {
        public KomisijaContext(DbContextOptions<KomisijaContext> options) : base(options)
        {

        }

        public DbSet<LicnostKomisije> LicnostiKomisije { get; set; }
        public DbSet<KomisijaModel> Komisije { get; set; }

        
    }
}
