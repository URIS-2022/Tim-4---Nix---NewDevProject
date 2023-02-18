using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Komisija.Models;
using System;

namespace Komisija.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<KomisijaContext>());
            }
        }

        private static void SeedData(KomisijaContext context)
        {

                Console.WriteLine("---Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            

            if (!context.Komisije.Any())
            {
                Console.WriteLine("--> Seeding data about Komisija...");
                context.Komisije.AddRange(
                    new KomisijaModel() { komisijaId = Guid.Parse("22FA4B7D-3ECA-43C6-9903-6EEA5A0AE10B"), nazivKomisije = "Prva komisija", oznakaKomisije = "kom123ef" },
                    new KomisijaModel() { komisijaId = Guid.Parse("C009D177-1815-49D8-ACDB-B60BCCC403CA"), nazivKomisije = "Nova komisija", oznakaKomisije = "kom345ef" }
                    );
                context.SaveChanges();
            }
            else
                Console.WriteLine("--> Data is alredy loaded...");

            if (!context.LicnostiKomisije.Any())
            {
                Console.WriteLine("--> Seeding data about LicnostKomisije...");
                context.LicnostiKomisije.AddRange(
                    new LicnostKomisije() { licnostKomisijeId = Guid.Parse("48C9BD59-8C21-4B6E-9F6C-325C39AE0E93"), imeLicnostiKomisije = "Marko", prezimeLicnostiKomisije = "Stojanovic", funkcijaLicnostiKomisije = "Pomocnik", komisijaId = Guid.Parse("22FA4B7D-3ECA-43C6-9903-6EEA5A0AE10B"), kontaktLicnostiKomisije = "0645371333", datumRodjenjaLicnostiKomisije = DateTime.Parse("1999-01-02"), oznakaKomisije = "kom123ef" },
                    new LicnostKomisije() { licnostKomisijeId = Guid.Parse("D4C1205F-5B9F-472F-8838-86F99FDBBA1E"), imeLicnostiKomisije = "Sonja", prezimeLicnostiKomisije = "Stojanovic", funkcijaLicnostiKomisije = "Prva postava", komisijaId = Guid.Parse("22FA4B7D-3ECA-43C6-9903-6EEA5A0AE10B"), kontaktLicnostiKomisije = "0617825713", datumRodjenjaLicnostiKomisije = DateTime.Parse("1989-09-18"), oznakaKomisije = "kom123ef" },
                    new LicnostKomisije() { licnostKomisijeId = Guid.Parse("4640C814-C340-4A9D-8D27-77F0B7F45602"), imeLicnostiKomisije = "Petar", prezimeLicnostiKomisije = "Petrovic", funkcijaLicnostiKomisije = "Obican clan", komisijaId = Guid.Parse("C009D177-1815-49D8-ACDB-B60BCCC403CA"), kontaktLicnostiKomisije = "0672514739", datumRodjenjaLicnostiKomisije = DateTime.Parse("1976-01-19"), oznakaKomisije = "kom345ef" },
                    new LicnostKomisije() { licnostKomisijeId = Guid.Parse("C96E40B0-9CFD-405B-9A41-452B90CB4BDF"), imeLicnostiKomisije = "Mina", prezimeLicnostiKomisije = "Zlatic", funkcijaLicnostiKomisije = "Predsednik", komisijaId = Guid.Parse("C009D177-1815-49D8-ACDB-B60BCCC403CA"), kontaktLicnostiKomisije = "0651516733", datumRodjenjaLicnostiKomisije = DateTime.Parse("1971-09-01"), oznakaKomisije = "kom345ef" }
                    );
                context.SaveChanges();
            }
            else
                Console.WriteLine("--> Data is alredy loaded...");

        }
    }
}
