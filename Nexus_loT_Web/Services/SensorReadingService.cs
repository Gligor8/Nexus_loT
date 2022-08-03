using Microsoft.AspNetCore.Mvc;
using Nexus_loT.DataAccess.Repository.IRepository;
using Nexus_loT.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nexus_loT_Web.Services
{
    
    
    public class SensorReadingService
    {
        private readonly IReadingRepository _readingRepository;
        private readonly ISensorRepository _sensorRepository;
        public SensorReadingService(IReadingRepository readingRepository, ISensorRepository sensorRepository)
        {
            _readingRepository = readingRepository;
            _sensorRepository = sensorRepository;
        }

        [HttpGet]
        public async Task<Reading> ReadFromSensorAsync(string APIUrl)
        {
            var getAPIUrlFromDb = _sensorRepository.GetAll().FirstOrDefault(x => x.APIUrl == APIUrl);
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(APIUrl);
        }

    }
}
