using KupacService.Models;
using KupacService.ServiceCall;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

namespace KupacService.ServiceCalls
{
    /// <summary>
    /// Servis za komunikaciju sa Uplatom
    /// </summary>
    public class UplataService : IUplataService
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="configuration"></param>
        public UplataService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Get metoda za uplate
        /// </summary>
        /// <param name="kupacId"></param>
        /// <returns></returns>
        public async Task<List<UplataDTO>> GetUplateByKupacID(Guid kupacId)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri url = new Uri($"{configuration["Services:UplataService"]}uplate/" + kupacId);
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
                    return JsonConvert.DeserializeObject<List<UplataDTO>>(content);
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
