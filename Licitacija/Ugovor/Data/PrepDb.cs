using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Ugovor.Models;

namespace Ugovor.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<UgovorDbContext>(), isProd);
            }
        }

        private static void SeedData(UgovorDbContext context, bool isProd)
        {

            if(isProd)
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
            }
            

            if (!context.Ugovori.Any())
            {
                Console.WriteLine("--> Seeding data about Ugovori...");
                context.Ugovori.AddRange(
                    new UgovorModel()
                    {
                        UgovorId = Guid.Parse("13CE5E68-EB23-4E33-BCBA-D463AC6EC5F6"),
                        LicitacijaId = Guid.Parse("4E1F1F8D-A8F7-44B1-9BDA-1C1EE122628D"),
                        TipGarancije = TipGarancije.Jemstvo,
                        LiceId = Guid.Parse("919b3994-6c05-44b9-8f6b-47e0378491d1"),
                        RokDospeca = 30,
                        ZavodniBroj = "1233",
                        DatumZavodjenja = DateTime.Now,
                        RokZaVracanjeZemljista = DateTime.Parse("2021-12-23T00:00:00"),
                        MestoPotpisivanja = "Subotica",
                        DatumPotpisa = DateTime.Now
                    },
                    new UgovorModel()
                    {
                        UgovorId = Guid.Parse("950713d6-f551-4b46-af25-5f8ec8f3e0aa"),
                        LicitacijaId = Guid.Parse("3F8AA5B3-A67F-45B5-B518-771A7C09A944"),
                        TipGarancije = TipGarancije.GarancijaNekretninom,
                        LiceId = Guid.Parse("e6aefc80-8d6b-42df-b5da-f5ec9f24600f"),
                        RokDospeca = 30,
                        ZavodniBroj = "4521",
                        DatumZavodjenja = DateTime.Now,
                        RokZaVracanjeZemljista = DateTime.Parse("2021-12-27T00:00:00"),
                        MestoPotpisivanja = "Subotica",
                        DatumPotpisa = DateTime.Now
                    });
            }
        }
    }
}
