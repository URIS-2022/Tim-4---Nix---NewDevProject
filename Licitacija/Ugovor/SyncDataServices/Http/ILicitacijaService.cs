using System.Threading.Tasks;
using System;
using Ugovor.Dtos;

namespace Ugovor.SyncDataServices.Http
{
    public interface ILicitacijaService
    {
        public Task<LicitacijaDto> GetLicitacijaById(Guid licitacijaId);
    }
}
