using JavnoNadmetanje.Enums;
using JavnoNadmetanje.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Data
{
    /// <summary>
    /// klasa kojom punim tabelu sa 2 nasumicno definisana primera
    /// </summary>
    public class PrepDB
    {
        /// <summary>
        /// poziva SeadData() funkciju
        /// </summary>
        /// <param name="app"></param>
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<JavnoNadmetanjeContext>());
            }
        }

        /// <summary>
        /// funkcija gde definisemo ta 2 primera
        /// </summary>
        /// <param name="context"></param>
        private static void SeedData(JavnoNadmetanjeContext context)
        {
            Console.WriteLine("Applying migrations");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.Write("COuldnt run migrations : {ex.Message} ");
            }

            if (!context.JavnaNadmetanja.Any())
            {
                Console.WriteLine("Seeding Data...");
                context.JavnaNadmetanja.AddRange(new JavnoNadmetanjeModel()
                {
                    JavnoNadmetanjeID = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    DatumNadmetanja = DateTime.Parse("10-02-2022"),
                    VremePocetka = DateTime.Parse("9:00:00"),
                    VremeKraja = DateTime.Parse("13:00:00"),
                    Izuzeto = false,
                    PocetnaCenaPoHektaru = 2000,
                    IzlicitiranaCena = 1500,
                    PeriodZakupa = 3,
                    BrojUcesnika = 25,
                    VisinaDopuneDepozita = 500,
                    Krug = 1,
                    PrijavljeniKupci = 15,
                    Tip = TipJavnogNadmetanja.JavnaLicitacija,
                    Status = StatusJavnogNadmetanja.PrviKrug,
                    KatastarskaOpstina = KatastarskeOpstine.Palic,
                }, 
                new JavnoNadmetanjeModel()
                {
                    JavnoNadmetanjeID = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e965b"),
                    DatumNadmetanja = DateTime.Parse("11-02-2022"),
                    VremePocetka = DateTime.Parse("10:00:00"),
                    VremeKraja = DateTime.Parse("14:00:00"),
                    Izuzeto = true,
                    PocetnaCenaPoHektaru = 1500,
                    IzlicitiranaCena = 900,
                    PeriodZakupa = 5,
                    BrojUcesnika = 10,
                    VisinaDopuneDepozita = 250,
                    Krug = 2,
                    PrijavljeniKupci = 30,
                    Tip = TipJavnogNadmetanja.OtvaranjeZatvorenihPonuda,
                    Status = StatusJavnogNadmetanja.DrugiKrugNoviUslovi,
                    KatastarskaOpstina = KatastarskeOpstine.BackiVinogradi,
                });

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("We already have data");
            }
        }
    }
}
