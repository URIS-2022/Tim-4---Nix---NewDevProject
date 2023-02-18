using AutoMapper;
using Komisija.Auth;
using Komisija.Data;
using Komisija.Dtos;
using Komisija.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Komisija.Controllers
{
    /// <summary>
    /// Komisija controller sa CRUD endpointima
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class KomisijaController : ControllerBase
    {
        private readonly IKomisijaRepository _komisijaRepository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        public KomisijaController(IKomisijaRepository komisijaRepository, IMapper mapper, IAuthHelper authHelper)
        {
            _komisijaRepository = komisijaRepository;
            _mapper = mapper;
            _authHelper = authHelper;
        }



        /// <summary>
        /// Vraca listu svih komisija
        /// </summary>
        /// <param name="naziv">Naziv komisije</param>
        /// <param name="oznakaKomisije">Oznaka komisije</param>
        /// <returns>Lista svih komisija</returns>
        /// <response code="200">Success answer - return all komisije</response>
        /// <response code="204">No content</response>
        /// <response code="500">Server error</response>
        [HttpGet]
        [HttpHead]
        [AllowAnonymous]
        public ActionResult<IEnumerable<KomisijaDto>> GetAll()
        {
            Console.WriteLine("--> getting Komisije");
            var komisije = _komisijaRepository.GetAll();

            if (komisije == null || !komisije.Any())
            {
                return NoContent();
            }
            
            return Ok(_mapper.Map<IEnumerable<KomisijaDto>>(komisije));
        }

        /// <summary>
        /// Vraca komisiju sa specificiranim komisijaId
        /// </summary>
        /// <param name="komisijaId">Jedinstevni identifikator komisije</param>
        /// <response code="200">Success - vraca komisiju sa vrednosti identifikatora komisijaId</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{komisijaId}")]
        [AllowAnonymous]
        public ActionResult<KomisijaDto> GetKomisijaById(Guid id)
        {
            var komisijaItem = _komisijaRepository.GetKomisijaById(id);
            if (komisijaItem != null)
            {
                return Ok(_mapper.Map<KomisijaDto>(komisijaItem));
            }

            return NotFound();
        }

        // <summary>
        /// Dodaj novu komisiju
        /// </summary>
        /// <param name="KomisijaDto">Model komisije</param>
        /// <param name="key">Authorization Key Value</param>
        /// <response code="201">Success - vraca kreirane komisije</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="500">Server error</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<KomisijaDto> CreateKomisija(KomisijaCreationDto komisijaCreationDto, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var komisijaModel = _mapper.Map<KomisijaModel>(komisijaCreationDto);
                _komisijaRepository.CreateKomisija(komisijaModel);
                _komisijaRepository.SaveChanges();

                var komisijaDto = _mapper.Map<KomisijaDto>(komisijaModel);

                return CreatedAtRoute(nameof(GetKomisijaById), new { komisijaId = komisijaDto.komisijaId }, komisijaDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating");
            }
        }

        /// <summary>
        /// Update komisiju
        /// </summary>
        /// <param name="komisijaUpdateDto">Model komisije</param>
        /// <param name="komisijaId">jedinstevni identifikator komisije</param>
        /// <param name="key">Authorization Key Value</param>
        /// <response code="200">Success answer - update-ovana komisija</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="403">Not allowed</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Server error</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{komisijaId}")]
        public ActionResult<KomisijaConfirmationDto> UpdateKomisija( KomisijaUpdateDto komisija, Guid komisijaId, [FromHeader(Name = "Authorization")] string key)
        {
            if(!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldKomisija = _komisijaRepository.GetKomisijaById(komisijaId);
                if(oldKomisija == null)
                {
                    return NotFound();
                }
                KomisijaModel komisijaEntity = _mapper.Map<KomisijaModel>(komisija);
                _komisijaRepository.SaveChanges();
                return Ok(_mapper.Map<KomisijaDto>(oldKomisija));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating");
            }
        }

        /// <summary>
        /// Obrisi komisiju
        /// </summary>
        /// <param name="komisijaId">Jedinstevni identifikator komisije</param>
        /// <param name="key">Authorization Key Value</param>
        /// <response code="200">Success answer</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="403">Not allowed</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{komisijaId}")]
        public IActionResult DeleteKomisija(Guid komisijaId, [FromHeader(Name = "Authorization")] string key)
        {
            if(!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var komisija = _komisijaRepository.GetKomisijaById(komisijaId);
                if(komisija == null)
                {
                    return NotFound();
                }
                _komisijaRepository.DeleteKomsija(komisijaId);
                _komisijaRepository.SaveChanges();
                return NoContent();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting");
            }
        }
        /// <summary>
        /// Vraća opcije za rad sa parcelama
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetKomisijaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }




    }
}
