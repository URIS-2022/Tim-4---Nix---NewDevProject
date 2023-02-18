using AutoMapper;
using Komisija.Dtos;
using Komisija.Models;

namespace Komisija.Profiles
{
    public class KomisijaProfile : Profile
    {
        /// <summary>
        /// Klasa koja omogucava mapiranje interne i eksterne reprezentacije podataka vezane za kvalitet zemljista.
        /// </summary>

        public KomisijaProfile()
        {
            CreateMap<KomisijaModel, KomisijaDto>();
            CreateMap<KomisijaDto, KomisijaModel>();
            CreateMap<KomisijaCreationDto, KomisijaModel>();
            CreateMap<KomisijaUpdateDto, KomisijaModel>();
            CreateMap<KomisijaModel, KomisijaModel>();
        }


    }
}
