//using AutoMapper;
using Nexus_loT.DataAccess.Repository.IRepository;
using Nexus_loT.Models;
using Nexus_loT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //var sensorFromDb = _db.Sensors.FirstOrDefault(x => x.Id == id);

            Sensor mappedSensor = new Sensor()
            {
                Id = entity.Id,
                Name = entity.Name,
                ClusterId = entity.ClusterId,
                Cluster = entity.Cluster,
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

            //var mappedSensor = _mapper.Map<Sensor>(entity);
            _db.Sensors.Add(mappedSensor);
            _db.SaveChanges();
            
            
        }

        public void Edit(SensorVM entity, string id)
        {
            Sensor mappedSensor = new Sensor()
            {
                Id = entity.Id,
                Name = entity.Name,
                ClusterId = entity.ClusterId,
                Cluster = entity.Cluster,
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

            _db.Sensors.Update(mappedSensor);
            _db.SaveChanges();
        }

        public IEnumerable<Sensor> GetAll()
        {
            IEnumerable<Sensor> sensorsDM = _db.Sensors.ToList();
            return sensorsDM;

        }

        public Sensor GetById(string id)
        {
            var sensorFromDb = _db.Sensors.FirstOrDefault(x => x.Id.Equals(id));
            return sensorFromDb;
        }

        public void Remove(string id)
        {
            var sensorFromDb = _db.Sensors.FirstOrDefault(x => x.Id.Equals(id));

            SensorVM mappedSensor = new SensorVM()
            {
                Id = sensorFromDb.Id,
                Name = sensorFromDb.Name,
                ClusterId = sensorFromDb.ClusterId,
                Cluster = sensorFromDb.Cluster,
                SensorTypeId = sensorFromDb.SensorTypeId,
                SensorType = sensorFromDb.SensorType,
                APIUrl = sensorFromDb.APIUrl,
                X = sensorFromDb.X,
                Y = sensorFromDb.Y,
                Configuration = sensorFromDb.Configuration,
                SerialNumber = sensorFromDb.SerialNumber,
                Interval = sensorFromDb.Interval,
                IsActive = sensorFromDb.IsActive
            };
            _db.Remove(sensorFromDb);
            _db.SaveChanges();
        }
    }
}
