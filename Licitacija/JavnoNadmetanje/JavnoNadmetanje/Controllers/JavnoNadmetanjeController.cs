using AutoMapper;
using JavnoNadmetanje.Auth;
using JavnoNadmetanje.Data;
using JavnoNadmetanje.Dtos;
using JavnoNadmetanje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;

namespace JavnoNadmetanje.Controllers
{
    // Omogucava dodavanje dodatnih stvari, npr. status kodova
    [ApiController]
    [Route("api/javnoNadmetanje")]
    public class JavnoNadmetanjeController : ControllerBase
    {

        private readonly IJavnoNadmetanjeRepository javnoNadmetanjeRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly IAuthHelper authHelper;

        public JavnoNadmetanjeController(IJavnoNadmetanjeRepository javnoNadmetanjeRepository, IMapper mapper, LinkGenerator linkGenerator, IAuthHelper authHelper)
        {
            this.javnoNadmetanjeRepository = javnoNadmetanjeRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.authHelper = authHelper;
        }

        /// <summary>
        /// Vraca sva javna nadmetanja
        /// </summary>
        /// <returns>Lista svih javnih nadmetanja </returns>
        /// <response code = "200">Vraća listu javnih nadmetanja</response>
        /// <response code = "204">Ne postoji lista javnih nadmetanja</response>
        [AllowAnonymous]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<JavnoNadmetanjeReadDto>> GetAllJavnaNadmetanja()
        {
            Console.WriteLine("... Ucitavanje svih nadmetanja ...");

            var lista = javnoNadmetanjeRepository.GetAllJavnaNadmetanja();

            if (lista == null || lista.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<List<JavnoNadmetanjeReadDto>>(lista));
        }

        /// <summary>
        /// Vraca 1 javno nadmetanje sa prosledjenim id-jem
        /// </summary>
        /// <param name="javnoNadmetanjeID"> jedinstveno obelezje/kljuc javnog nadmetanja (Guid )</param>
        /// <returns>Vraca 1 javno nadmetanje</returns>
        [AllowAnonymous]
        [HttpGet("{javnoNadmetanjeID}", Name="GetJavnoNadmetanjeByID")]
        public ActionResult<JavnoNadmetanjeReadDto> GetJavnoNadmetanjeByID(Guid javnoNadmetanjeID)
        {
            var nadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanjeById(javnoNadmetanjeID);

            if (nadmetanje != null)
            {
                return Ok(mapper.Map<JavnoNadmetanjeReadDto>(nadmetanje));
            }

            return NotFound();
        }

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult<JavnoNadmetanjeReadDto> CreateJavnoNadmetanje(JavnoNadmetanjeCreateDto javnoNadmetanje, [FromHeader(Name = "Authorization")] string key)
        {
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Greska prilikom kreiranja javnog nadmetanja!");
            }
        }


        //********************************
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public ActionResult<JavnoNadmetanjeReadDto> UpdateJavnoNadmetanje(JavnoNadmetanjeUpdateDto javnoNadmetanje, [FromHeader(Name = "Authorization")] string key)
        {
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

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{javnoNadmetanjeID}")]
        public IActionResult DeleteJavnoNadmetanje(Guid javnoNadmetanjeID, [FromHeader(Name = "Authorization")] string key)
        {
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

        //vraca informacije o opcijama koje je moguće izvrsiti za sva javna nadmetanja
        [HttpOptions]
        public IActionResult GetJavnoNadmetanjeOptions()
        {
            Response.Headers.Add("Allow", "GET, HEAD, POST, PUT, DELETE");
            return Ok();
        }


    }
}
