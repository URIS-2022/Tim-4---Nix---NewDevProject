using AutoMapper;
using JavnoNadmetanje.Auth;
using JavnoNadmetanje.Data;
using JavnoNadmetanje.Dtos;
using JavnoNadmetanje.Logger;
using JavnoNadmetanje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;

namespace JavnoNadmetanje.Controllers
{
    /// <summary>
    /// u kontroleru se definisu sve CRUD operacije koje ce se vrsiti nad javnim nadmetanjem
    /// </summary>
    [Consumes("application/json")]
    [Produces("application/json", "application/xml")]
    [ApiController]
    [Route("api/javnoNadmetanje")]
    public class JavnoNadmetanjeController : ControllerBase
    {

        private readonly IJavnoNadmetanjeRepository javnoNadmetanjeRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly IAuthHelper authHelper;
        private readonly LoggerService loggerService;

        /// <summary>
        /// deklarisanje klase
        /// </summary>
        /// <param name="javnoNadmetanjeRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="linkGenerator"></param>
        /// <param name="authHelper"></param>
        public JavnoNadmetanjeController(IJavnoNadmetanjeRepository javnoNadmetanjeRepository, IMapper mapper, LinkGenerator linkGenerator, IAuthHelper authHelper)
        {
            this.javnoNadmetanjeRepository = javnoNadmetanjeRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.authHelper = authHelper;
            loggerService = new LoggerService();
        }

        /// <summary>
        /// Vraca sva javna nadmetanja
        /// </summary>
        /// <returns>Lista svih javnih nadmetanja </returns>
        /// <response code = "200">Vraca listu javnih nadmetanja</response>
        /// <response code = "204">Ne postoji lista javnih nadmetanja</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<JavnoNadmetanjeReadDto>> GetAllJavnaNadmetanja()
        {
            #pragma warning disable CS4014
            loggerService.PostLogger("Pristup svim javnim nadmetanjima." + "*********Korisnicko ime: " + HttpContext.User.Identity.Name);
            #pragma warning restore CS4014

            Console.WriteLine("... Ucitavanje svih nadmetanja ...");

            var lista = javnoNadmetanjeRepository.GetAllJavnaNadmetanja();

            if (lista == null || lista.Count == 0)
            {
                return StatusCode(StatusCodes.Status204NoContent, "Ne postoji ni jedno javno nadmetanje!");
            }

            return Ok(mapper.Map<List<JavnoNadmetanjeReadDto>>(lista));
        }

        /// <summary>
        /// Vraca 1 javno nadmetanje sa prosledjenim id-jem
        /// </summary>
        /// <param name="javnoNadmetanjeID"> jedinstveno obelezje/kljuc javnog nadmetanja (Guid )</param>
        /// <returns>Vraca trazeno javno nadmetanje</returns>
        /// <response code = "200">Vraca traženo javno nadmetanje</response>
        /// <response code = "404">Nije pronađeno traženo javno nadmetanje</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        [HttpGet("{javnoNadmetanjeID}", Name="GetJavnoNadmetanjeByID")]
        public ActionResult<JavnoNadmetanjeReadDto> GetJavnoNadmetanjeByID(Guid javnoNadmetanjeID)
        {
            loggerService.PostLogger("Pristup javnom nadmetanju sa unesenim id-jem." + "*********Korisnicko ime: " + HttpContext.User.Identity.Name);

            var nadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanjeById(javnoNadmetanjeID);

            if (nadmetanje != null)
            {
                return Ok(mapper.Map<JavnoNadmetanjeReadDto>(nadmetanje));
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "Ne postoji javno nadmetanje sa prosledjenim ID-jem!");
            }

        }

        /// <summary>
        /// Kreira novo javno nadmetanje
        /// </summary>
        /// <param name="javnoNadmetanje"> model javnog nadmetanja</param>
        /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer LenkaSubotin)</param>
        /// <returns>Potvrda o kreiranom javnom nadmetanju</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog javnog nadmetanja \
        /// POST /api/javnaNadmetanja \
        /// { \
        ///  "Datum" : "2022-02-10", \
        ///  "VremePocetka" : "9:00:00", \
        ///  "VremeKraja" : "13:00:00", \
        ///  "PocetnaCenaPoHektaru" : 2000, \
        ///  "Izuzeto" : false, \
        ///  "Tip" : "JavnaLicitacija", \
        ///  "IzlicitiranaCena" : 1500, \
        ///  "PeriodZakupa" : 3, \
        ///  "BrojUcesnika : 25", \
        ///  "VisinaDopuneDepozita" : 500, \
        ///  "Krug" : 1, \
        ///  "Status" : "PrviKrug", \
        ///  "LicitacijaId" : "861e7d2e-268f-495f-8bd3-dbfb4f0594a4", \
        ///  "ParcelaId: : "35d3c2da-7e55-4730-a4ed-9f886e24e6f9", \
        ///  "KupacId" : "bc03a6fb-b322-4797-b6c4-0a899615f653" \
        /// } 
        /// </remarks>
        /// <response code = "201">Vraca kreirano javno nadmetanje</response>
        /// <response code = "401">Lice koje želi da izvrsi kreiranje javnog nadmetanja nije autorizovani korisnik</response>
        /// <response code = "500">Doslo je do greske na serveru prilikom kreiranja javnog nadmetanja</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<JavnoNadmetanjeReadDto> CreateJavnoNadmetanje(JavnoNadmetanjeCreateDto javnoNadmetanje, [FromHeader(Name = "Authorization")] string key)
        {
            loggerService.PostLogger("Kreiranje novog javnog nadmetanjima." + "*********Korisnicko ime: " + HttpContext.User.Identity.Name);

            if (!authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                //bool modelValid = ValidationJavnoNadmetanje(javnoNadmetanje);

                //if (!modelValid)
                //{
                //    return BadRequest("Vreme kraja javnog nadmetanja mora biti nakon vremena pocetka javnog nadmetanja!");
                //}

                var javnoNadmetnjeModel = mapper.Map<JavnoNadmetanjeModel>(javnoNadmetanje);
                javnoNadmetanjeRepository.CreateJavnoNadmetanje(javnoNadmetnjeModel);
                javnoNadmetanjeRepository.SaveChanges();

                var javnoNadmetanjeDto = mapper.Map<JavnoNadmetanjeReadDto>(javnoNadmetnjeModel);

                return CreatedAtRoute(nameof(GetJavnoNadmetanjeByID), new { javnoNadmetanjeID = javnoNadmetanjeDto.JavnoNadmetanjeID }, javnoNadmetanjeDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greska na servisu prilikom kreiranja javnog nadmetanja!");
            }
        }

        /// <summary>
        /// Azuriranje samo dozvoljenih podataka definisanih u JavnoNadmetanjeUpdateDto
        /// </summary>
        /// <param name="javnoNadmetanje">dto sa podataka definisanih u JavnoNadmetanjeUpdateDto</param>
        /// <param name="key"></param>
        /// <returns>vraca ceo model javnog nadmetanja sa azuriranim podacima</returns>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<JavnoNadmetanjeReadDto> UpdateJavnoNadmetanje(JavnoNadmetanjeUpdateDto javnoNadmetanje, [FromHeader(Name = "Authorization")] string key)
        {
            loggerService.PostLogger("Azuriranje javnog nadmetanjima." + "*********Korisnicko ime: " + HttpContext.User.Identity.Name);

            if (!authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldNadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanjeById(javnoNadmetanje.JavnoNadmetanjeID);
                if (oldNadmetanje == null)
                {
                    return NotFound();
                }
                JavnoNadmetanjeModel newNadmetanje = mapper.Map<JavnoNadmetanjeModel>(javnoNadmetanje);
                mapper.Map(newNadmetanje, oldNadmetanje);
                javnoNadmetanjeRepository.SaveChanges();
                return Ok(mapper.Map<JavnoNadmetanjeReadDto>(oldNadmetanje));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greska prilikom azuriranja javnog nadmetanja!");
            }
        }

        /// <summary>
        /// Brise javno nadmetanje na osnovu ID-ja
        /// </summary>
        /// <param name="javnoNadmetanjeID">ID javnog nadmetanja</param>
        /// /// <param name="key"> ključ sa kojim se proverava autorizacija(key vrednost: Bearer LenkaSubotin)</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Javno nadmetanja uspesno obrisano</response>
        /// <response code="401">Lice koje želi da izvrsi brisanje nije autorizovani korisnik</response>
        /// <response code="404">Nije pronađeno javno nadmetanje za brisanje</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja javnog nadmetanja</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{javnoNadmetanjeID}")]
        public IActionResult DeleteJavnoNadmetanje(Guid javnoNadmetanjeID, [FromHeader(Name = "Authorization")] string key)
        {
            loggerService.PostLogger("Brisanje javnog nadmetanja sa prosledjenim id-jem." + "*********Korisnicko ime: " + HttpContext.User.Identity.Name);

            if (!authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var javnoNadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanjeById(javnoNadmetanjeID);
                if (javnoNadmetanje == null)
                {
                    return NotFound();
                }

                javnoNadmetanjeRepository.DeleteJavnoNadmetanje(javnoNadmetanje.JavnoNadmetanjeID);
                javnoNadmetanjeRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greska prilikom brisanja javnog nadmetanja!");
            }
        }

        /// <summary>
        /// Vraca informacije o opcijama koje je moguce izvrsiti za sva javna nadmetanja
        /// </summary>
        /// <returns>OK</returns>
        [HttpOptions]
        public IActionResult GetJavnoNadmetanjeOptions()
        {
            loggerService.PostLogger("Pristup opcijama za javno nadmetanje." + "*********Korisnicko ime: " + HttpContext.User.Identity.Name);

            Response.Headers.Add("Allow", "GET, HEAD, POST, PUT, DELETE");
            return Ok();
        }
    }
}
