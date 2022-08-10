using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nexus_loT.DataAccess.Repository.IRepository;
using Nexus_loT.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
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

        public HttpClient client = new HttpClient();

        public async Task ReadFromSensorAsync(string id)
        {
            var listAllActiveSensors = _sensorRepository.GetAll().Where(x => x.IsActive == true);

            
            Reading reading;

            foreach (var sensor in listAllActiveSensors)
            {
                
                var readings = _readingRepository.GetAll().OrderByDescending(x => x.DateRead).ToList();
                
                var lastReading = readings.FirstOrDefault(x => x.Id == id);


               
                
                    if (lastReading.Value != null)
                    {
                        if (DateTime.Now.AddMinutes(sensor.Interval) < lastReading.DateRead)
                        {
                            //odi ponatamu
                        }
                        else
                        {
                            //prati nov API request
                            //Sensor sensorMeasurement = null;
                            HttpResponseMessage response = await client.GetAsync(sensor.APIUrl).ConfigureAwait(true);
                            if (response.IsSuccessStatusCode)
                            {
                            //sensorMeasurement = await response.Content.ReadAsAsync<Sensor>();
                             string result = response.Content.ReadAsStringAsync().Result;
                             var responseObj = JsonConvert.DeserializeObject<Reading>(result);

                            _readingRepository.Add(responseObj);
                            }
                        //return sensorMeasurement;
                            
                       
                        }
                    
                    }
                    else
                    {
                        //prati nov API request
                        HttpResponseMessage response = await client.GetAsync(sensor.APIUrl).ConfigureAwait(true);
                        if (response.IsSuccessStatusCode)
                        {
                            //sensorMeasurement = await response.Content.ReadAsAsync<Sensor>();
                            string result = response.Content.ReadAsStringAsync().Result;
                            var responseObj = JsonConvert.DeserializeObject<Reading>(result);

                            _readingRepository.Add(responseObj);
                        }

                    }

                
            }

            //return listAllActiveSensors;
        }

        //public async Task<Reading> WriteToDB()
        //{
            

        //}

        //public async Task<Reading> FiltrateSensors(string sensorId)
        //{
        //    var getAllActiveSensors = _sensorRepository.GetAll().Where(x => x.IsActive == true);
        //    var activeSensor = _sensorRepository.GetById(sensorId);
        //    //var getAllActiveSensors = getAllSensors.

        //    if (activeSensor.IsActive == true)
        //    {
        //        return ReadFromSensorAsync();
        //    }
        //}

    }
}
