//using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nexus_loT.DataAccess.Repository.IRepository;
using Nexus_loT.Models;
using Nexus_loT.Models.ViewModels;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.DataAccess.Repository
{
    public class SensorRepository : ISensorRepository
    {
        private readonly ApplicationDbContext _db;
        //private readonly IMapper _mapper;
        public SensorRepository(ApplicationDbContext db) 
        {
            _db = db;
            //_mapper = mapper;
        }

        public void Add(SensorVM entity)
        {
           
            var schemaConfig = entity.Configuration;
            var schema = JsonSchema.FromSampleJson(schemaConfig);

            var prop = schema.Properties;
            foreach (var property in prop)
            {
                JsonSchemaProperty value = property.Value;
                value.IsRequired = true;
            }

            Sensor mappedSensor = new Sensor()
            {
                Id = entity.Id,
                Name = entity.Name,
                Clusters = entity.Clusters,
                SensorTypeId = entity.SensorTypeId,
                SensorType = entity.SensorType,
                APIUrl = entity.APIUrl,
                X = entity.X,
                Y = entity.Y,
                Configuration = entity.Configuration,
                ConfigurationSchema = schema.ToJson(),
                SerialNumber = entity.SerialNumber,
                Interval = entity.Interval,
                IsActive = entity.IsActive
            };

            
            
            _db.Sensors.Add(mappedSensor);
            _db.SaveChanges();
            
            
        }

        public void Edit(SensorVM entity, string id)
        {
            var schemaConfig = entity.Configuration;
            var schema = JsonSchema.FromSampleJson(schemaConfig);

            var prop = schema.Properties;
            foreach (var property in prop)
            {
                JsonSchemaProperty value = property.Value;
                value.IsRequired = true;
            }

            Sensor mappedSensor = new Sensor()
            {
                Id = entity.Id,
                Name = entity.Name,
                Clusters = entity.Clusters,
                SensorTypeId = entity.SensorTypeId,
                SensorType = entity.SensorType,
                APIUrl = entity.APIUrl,
                X = entity.X,
                Y = entity.Y,
                Configuration = entity.Configuration,
                ConfigurationSchema = schema.ToJson(),
                SerialNumber = entity.SerialNumber,
                Interval = entity.Interval,
                IsActive = entity.IsActive
            };

            _db.Sensors.Update(mappedSensor);
            _db.SaveChanges();
        }

        public IEnumerable<Sensor> GetAll(Expression<Func<Sensor, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<Sensor> sensorsDM = _db.Sensors;

            if (filter != null)
            {
                sensorsDM = sensorsDM.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    sensorsDM = sensorsDM.Include(includeProp);
                }
            }

            return sensorsDM;

        }

        public Sensor GetById(string id)
        {
            var sensorFromDb = _db.Sensors.FirstOrDefault(x => x.Id.Equals(id));
            return sensorFromDb;
        }

        public void Remove(SensorVM entity, string id)
        {
            //var sensorFromDb = _db.Sensors.FirstOrDefault(x => x.Id.Equals(id));

            Sensor mappedSensor = new Sensor()
            {
                Id = entity.Id,
                Name = entity.Name,
                Clusters = entity.Clusters,
                SensorTypeId = entity.SensorTypeId,
                SensorType = entity.SensorType,
                APIUrl = entity.APIUrl,
                X = entity.X,
                Y = entity.Y,
                Configuration = entity.Configuration,
                SerialNumber = entity.SerialNumber,
                Interval = entity.Interval,
                IsActive = entity.IsActive
            };

            var selectSensor = _db.Readings.Where(a => a.SensorId == mappedSensor.Id);
            foreach (var reading in selectSensor)
            {
                _db.Readings.Remove(reading);
            }
           
            _db.Sensors.Remove(mappedSensor);
            _db.SaveChanges();
        }
    }
}
