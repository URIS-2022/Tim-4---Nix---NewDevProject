using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Ugovor.Dtos;
using Microsoft.Extensions.Configuration;

namespace Ugovor.SyncDataServices.Http
{
    public class LicitacijaService : ILicitacijaService
    {
        private readonly IConfiguration _configuration;

        public LicitacijaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<LicitacijaDto> GetLicitacijaById(Guid licitacijaId)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri url = new Uri($"{_configuration["Services:LicitacijaService"]}/api/licitacije/" + licitacijaId);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Accept", "application/json");
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        return default;
                    }
                    return JsonConvert.DeserializeObject<LicitacijaDto>(content);
                }
                return default;
            }
            catch
            {
                return default;
            }
        }
    }
}
