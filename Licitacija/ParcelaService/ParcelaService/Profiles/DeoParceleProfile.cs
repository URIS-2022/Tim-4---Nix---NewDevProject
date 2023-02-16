using AutoMapper;
using ParcelaService.DTOs.CreateDto;
using ParcelaService.DTOs.UpdateDto;
using ParcelaService.DTOs;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    /// <summary>
    /// Klasa koja omogucava mapiranje interne i eksterne reprezentacije podataka vezane za deo parcele.
    /// </summary>
    public class DeoParceleProfile : Profile
    {
        public DeoParceleProfile() 
        {
            CreateMap<DeoParcele, DeoParceleDto>();
            CreateMap<DeoParceleDto, DeoParcele>();
            CreateMap<DeoParceleCreateDto, DeoParcele>();
            CreateMap<DeoParceleUpdateDto, DeoParcele>();
            CreateMap<DeoParcele, DeoParcele>();
        }
    }
}
