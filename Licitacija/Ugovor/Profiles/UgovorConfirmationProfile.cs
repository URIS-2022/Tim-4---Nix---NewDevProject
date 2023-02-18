using AutoMapper;
using Ugovor.Dtos;
using Ugovor.Models;

namespace Ugovor.Profiles
{
    public class UgovorConfirmationProfile : Profile
    {
        public UgovorConfirmationProfile()
        {
            CreateMap<UgovorConfirmation, UgovorConfirmationDto>();
            CreateMap<UgovorModel, UgovorConfirmationDto>();
            CreateMap<UgovorModel, UgovorConfirmation>();
        }
    }
}
