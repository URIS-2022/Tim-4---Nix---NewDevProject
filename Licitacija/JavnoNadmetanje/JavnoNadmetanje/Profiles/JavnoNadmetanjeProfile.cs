using AutoMapper;
using JavnoNadmetanje.Dtos;
using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Profiles
{
    public class JavnoNadmetanjeProfile : Profile
    {
        public JavnoNadmetanjeProfile()
        {
            CreateMap<JavnoNadmetanjeModel, JavnoNadmetanjeReadDto>();
            CreateMap<JavnoNadmetanjeReadDto, JavnoNadmetanjeModel>();
            CreateMap<JavnoNadmetanjeCreateDto, JavnoNadmetanjeModel>();
            CreateMap<JavnoNadmetanjeModel, JavnoNadmetanjeCreateDto>();
            CreateMap<JavnoNadmetanjeModel, JavnoNadmetanjeModel>();
        }
    }
}
