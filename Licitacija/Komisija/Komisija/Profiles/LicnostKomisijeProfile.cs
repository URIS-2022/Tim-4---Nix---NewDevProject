using AutoMapper;
using Komisija.Dtos;
using Komisija.Models;

namespace Komisija.Profiles
{
    public class LicnostKomisijeProfile : Profile
    {
        /// <summary>
        /// Klasa koja omogucava mapiranje interne i eksterne reprezentacije podataka vezane za komisiju.
        /// </summary>

        public LicnostKomisijeProfile()
        {
            CreateMap<LicnostKomisije, LicnostKomisijeDto>();
            CreateMap<LicnostKomisijeDto, LicnostKomisije>();
            CreateMap<LicnostKomisijeCreationDto, LicnostKomisije>();
            CreateMap<LicnostKomisijeUpdateDto, LicnostKomisije>();
            CreateMap<LicnostKomisije, LicnostKomisije>();
        }


    }
}

