using AutoMapper;
using JavnoNadmetanje.Dtos;
using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Profiles
{
    /// <summary>
    /// klasa profila javnog nadmetanja
    /// </summary>
    public class JavnoNadmetanjeProfile : Profile
    {
        /// <summary>
        /// Ovde se kreiraju sva moguca mapiranja koja mozemo izvrsiti sa CRUD operacijama
        /// </summary>
        public JavnoNadmetanjeProfile()
        {
            CreateMap<JavnoNadmetanjeModel, JavnoNadmetanjeReadDto>();
            CreateMap<JavnoNadmetanjeReadDto, JavnoNadmetanjeModel>();
            CreateMap<JavnoNadmetanjeCreateDto, JavnoNadmetanjeModel>();
            CreateMap<JavnoNadmetanjeModel, JavnoNadmetanjeCreateDto>();
            CreateMap<JavnoNadmetanjeModel, JavnoNadmetanjeModel>();
            CreateMap<JavnoNadmetanjeModel, JavnoNadmetanjeUpdateDto>();
            CreateMap<JavnoNadmetanjeUpdateDto, JavnoNadmetanjeModel>();
            CreateMap<JavnoNadmetanjeReadDto, JavnoNadmetanjeUpdateDto>();
            CreateMap<JavnoNadmetanjeUpdateDto, JavnoNadmetanjeReadDto>();
        }
    }
}
