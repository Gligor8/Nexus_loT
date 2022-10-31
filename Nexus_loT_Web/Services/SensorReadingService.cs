using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Nexus_loT.DataAccess.Repository.IRepository;
using Nexus_loT.Models;
using NJsonSchema;
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


        /// <summary>
        /// Reads data from API. Check the time inverval of a reading and sends a request if the time of previous reading excedes one minute.
        /// Validates the received Json against a jsonschema which is generated from the configuration of a sensor. The method is being activated from a hangfire job in startup.cs.
        /// </summary>
        /// <returns></returns>
        public async Task ReadFromSensorAsync()
       {
            try
            {
                HttpClient client = new HttpClient();
                var listAllActiveSensors = _sensorRepository.GetAll().Where(x => x.IsActive == true);



                foreach (var sensor in listAllActiveSensors)
                {

                    var readings = _readingRepository.GetAll().Where(x => x.SensorId == sensor.Id).OrderByDescending(x => x.DateRead); //Where(x => x.Value.Equals(sensor)); //OrderBy(x => x.SensorId == sensor.Id)

                    var lastReading = readings.LastOrDefault();



                    if (lastReading != null)
                    {
                        if (DateTime.UtcNow < lastReading.DateRead.AddMinutes(sensor.Interval))
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
                                

                                var schema = await NJsonSchema.JsonSchema.FromJsonAsync(sensor.ConfigurationSchema);
                                
                                var errors = schema.Validate(result);



                                if (errors.Count == 0)
                                {
                                    var readingObj = new Reading() { SensorId = sensor.Id, Value = result };
                                    _readingRepository.Add(readingObj);
                                }
                                else
                                {
                                    // treba errorite da se zapisat vo log
                                    Console.WriteLine();
                                }

                            }



                        }

                    }
                    else
                    {
                        
                        //prati nov API request
                        HttpResponseMessage response = await client.GetAsync(sensor.APIUrl);
                        if (response.IsSuccessStatusCode)
                        {

                            string result = response.Content.ReadAsStringAsync().Result;
                            

                            var schema = await NJsonSchema.JsonSchema.FromJsonAsync(sensor.ConfigurationSchema);
                            
                            var errors = schema.Validate(result);



                            if (errors.Count == 0)
                            {
                                var readingObj = new Reading() { SensorId = sensor.Id, Value = result };
                                _readingRepository.Add(readingObj);
                            }
                            else
                            {
                                // treba errorite da se zapisat vo log
                                Console.WriteLine();
                            }


                        }


                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            

            
        }

        
       
    }
}
