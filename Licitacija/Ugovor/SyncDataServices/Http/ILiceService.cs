using System.Threading.Tasks;
using System;
using Ugovor.Dtos;

namespace Ugovor.SyncDataServices.Http
{
    public interface ILiceService
    {
        public Task<LiceDto> GetLiceById(Guid liceId);
    }
}
