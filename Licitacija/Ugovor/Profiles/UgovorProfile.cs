using AutoMapper;
using Ugovor.Dtos;
using Ugovor.Models;

namespace Ugovor.Profiles
{
    public class UgovorProfile : Profile
    {
        public UgovorProfile()
        {
            //Source -> target
            CreateMap<UgovorModel, UgovorDto>();
            CreateMap<UgovorDto, UgovorModel>();
            CreateMap<UgovorCreateDto, UgovorModel>();
            CreateMap<UgovorUpdateDto, UgovorModel>();
            CreateMap<UgovorModel, UgovorModel>();

        }
    }
}
