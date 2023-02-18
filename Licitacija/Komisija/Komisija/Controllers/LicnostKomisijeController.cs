using AutoMapper;
using Komisija.Auth;
using Komisija.Data;
using Komisija.Dtos;
using Komisija.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Komisija.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class LicnostKomisijeController : ControllerBase
    {
        private readonly ILicnostKomisijeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;

        public LicnostKomisijeController(ILicnostKomisijeRepository repository, IMapper mapper, IAuthHelper authHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraca listu svih licnosti komisije
        /// </summary>
        /// <param name="imeLicnostiKomisije">Ime licnosti komisije</param>
        /// <param name="prezimeLicnostiKomisije">Prezime licnosti komisije</param>
        /// <param name="oznakaKomisije">Oznaka komisije</param>
        /// <returns>Lista svih licnosti komisije</returns>
        /// <response code="200">Success answer - return all licnosti komisije</response>
        /// <response code="204">No content</response>
        /// <response code="500">Server error</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult <IEnumerable<LicnostKomisijeDto>> GetAll()
        {
            Console.WriteLine("--> getting LicnostiKomisije");
            var licnostiKomisije = _repository.GetAll();
            if(licnostiKomisije == null || licnostiKomisije.Count() == 0)
            {
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<LicnostKomisijeDto>>(licnostiKomisije));
        }

        /// <summary>
        /// Vraca licnost komisije sa specificiranim licnostKomisijeId
        /// </summary>
        /// <param name="licnostKomisijeId">Jedinstevni identifikator licnosti komisije</param>
        /// <response code="200">Success - vraca licnost komisije sa vrednosti identifikatora licnostKomisijeId</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{licnostKomisijeId}")]
        [AllowAnonymous]
        public ActionResult<LicnostKomisijeDto> GetLicnostiKomisijeById (Guid licnostKomisijeId)
        {
            var licnostKomisijeItem = _repository.GetLicnostKomisijeById(licnostKomisijeId);
            if(licnostKomisijeItem != null)
            {
                return Ok(_mapper.Map<LicnostKomisijeDto>(licnostKomisijeItem));
            }
            return NotFound();
        }

        /// <summary>
        /// Dodaj novu licnost komisije
        /// </summary>
        /// <param name="LicnostKomisijeDto">Model licnosti komisije</param>
        /// <param name="key">Authorization Key Value</param>
        /// <response code="201">Success - vraca kreiranu licnost komisije</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="500">Server error</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<LicnostKomisijeDto> CreateLicnostKomisije(LicnostKomisijeCreationDto licnostKomisijeCreationDto, [FromHeader(Name = "Authorization")] string key)
        {
            if(!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var licnostKomisijeModel = _mapper.Map<LicnostKomisije>(licnostKomisijeCreationDto);
                _repository.CreateLicnostKomisije(licnostKomisijeModel);
                _repository.SaveChanges();

                var licnostKomisijeDto = _mapper.Map<LicnostKomisijeDto>(licnostKomisijeModel);

                return CreatedAtRoute(nameof(GetLicnostiKomisijeById), new { licnostKomisijeId = licnostKomisijeDto.licnostKomisijeId }, licnostKomisijeDto);

            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating");
            }
        }

        /// <summary>
        /// Update licnost komisije
        /// </summary>
        /// <param name="licnostKomisijeUpdateDto">Model licnosti komisije</param>
        /// <param name="licnostKomisijeId">jedinstevni identifikator licnosti komisije</param>
        /// <param name="key">Authorization Key Value</param>
        /// <response code="200">Success answer - update-ovana licnost komisije</response>
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
        [HttpPut("{licnostKomisijeId}")]
        public ActionResult<LicnostKomisijeConfirmationDto> UpdateLicnostKomisije(LicnostKomisijeUpdateDto licnostKomisije, Guid licnostKomisijeId, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var oldLicnostKomisije = _repository.GetLicnostKomisijeById(licnostKomisijeId);
                if(oldLicnostKomisije == null)
                {
                    return NotFound();
                }
                LicnostKomisije licnostKomisijeEntity = _mapper.Map<LicnostKomisije>(licnostKomisije);
                _mapper.Map(licnostKomisijeEntity, oldLicnostKomisije);
                _repository.SaveChanges();
                return Ok(_mapper.Map<LicnostKomisijeDto>(oldLicnostKomisije));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating");
            }
        }

        /// <summary>
        /// Obrisi licnost komisije
        /// </summary>
        /// <param name="licnostKomisijeId">Jedinstevni identifikator licnosti komisije</param>
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
        [HttpDelete("{licnostKomisijeId}")]
        public IActionResult DeleteLicnostKomisije(Guid licnostKomisijeId, [FromHeader(Name = "Authorization")] string key)
        {
            if (!_authHelper.Authorize(key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Korisnik nije autorizovan!");
            }
            try
            {
                var licnostKomisije = _repository.GetLicnostKomisijeById(licnostKomisijeId);
                if(licnostKomisijeId == null)
                {
                    return NotFound();
                }
                _repository.DeleteLicnostKomisije(licnostKomisijeId);
                _repository.SaveChanges();
                return NoContent();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting");
            }
        }

        /// <summary>
        /// Vraca implementirane opcije rada sa servisom
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetLicnostKomisijeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
