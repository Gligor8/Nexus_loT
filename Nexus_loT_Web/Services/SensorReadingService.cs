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

        public async Task ReadFromSensorAsync()
        {
            HttpClient client = new HttpClient();
            var listAllActiveSensors = _sensorRepository.GetAll().Where(x => x.IsActive == true);

            
            //Reading reading;
            //var readings = _readingRepository.GetAll().Where(x => x.Sensor.IsActive == true).OrderByDescending(x => x.DateRead);
            //var lastReading = readings.FirstOrDefault();
            foreach (var sensor in listAllActiveSensors)
            {

                var readings = _readingRepository.GetAll().Where(x => x.SensorId == sensor.Id).OrderByDescending(x => x.DateRead); //Where(x => x.Value.Equals(sensor)); //OrderBy(x => x.SensorId == sensor.Id)
                
                var lastReading = readings.FirstOrDefault();



                if (lastReading != null)
                {
                    if (DateTime.Now.AddMinutes(sensor.Interval) < lastReading.DateRead)
                    {
                        //odi ponatamu
                    }
                    else
                    {
                        //prati nov API request
                        
                        HttpResponseMessage response = await client.GetAsync(sensor.APIUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            
                            string result = response.Content.ReadAsStringAsync().Result;
                            //var responseObj = JsonConvert.DeserializeObject<Reading>(result);
                            var readingObj = new Reading() { SensorId = sensor.Id, Value = result };
                            _readingRepository.Add(readingObj);
                        }
                        


                    }

                }
                else
                {
                    //prati nov API request
                    HttpResponseMessage response = await client.GetAsync(sensor.APIUrl).ConfigureAwait(true);
                    if (response.IsSuccessStatusCode)
                    {

                        string result = response.Content.ReadAsStringAsync().Result;
                        //var responseObj = JsonConvert.DeserializeObject<Reading>(result);
                        var readingObj = new Reading() { SensorId = sensor.Id, Value = result };
                        _readingRepository.Add(readingObj);
                    }

                }


            }

            
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
