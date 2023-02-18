using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Licitacija1.Entities;

namespace Licitacija1.Data
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> opt) : base (opt)
        {

        }
         
        public DbSet<LicitacijaModel> Licitacije { get; set; }
        public DbSet<DokumentModel> Dokumenti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<LicitacijaModel>().HasMany(x => x.dokumentFizickaLica).WithOne(x => x.licitacija).HasForeignKey(x => x.licitacijaID);

        }
    }
}
