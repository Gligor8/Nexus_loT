using Nexus_loT.DataAccess.Repository.IRepository;
using Nexus_loT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nexus_loT.DataAccess.Repository
{
    public class MeasurementUnitRepository : Repository<MeasurementUnit, string>, IMeasurementUnitRepository
    {
        private readonly ApplicationDbContext _db;
        public MeasurementUnitRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        //public void Add(MeasurementUnit entity)
        //{
        //    _db.MeasurementUnits.Add(entity);
        //    //_db.SaveChanges();
        //}

        //public void Edit(MeasurementUnit entity)
        //{
        //    _db.MeasurementUnits.Update(entity);
        //    _db.SaveChanges();
        //}

        //public IEnumerable<MeasurementUnit> GetAll()
        //{
        //    return _db.MeasurementUnits.ToList();
        //}

        //public MeasurementUnit GetById(string id)
        //{
        //    return _db.MeasurementUnits
        //        .SingleOrDefault(x => x.Id == id);
        //}

        //public void MeasurementUnit(string id)
        //{
        //    MeasurementUnit measurementUnit = _db.MeasurementUnits.SingleOrDefault(x => x.Id == id);
        //    _db.MeasurementUnits.Remove(measurementUnit);
        //    _db.SaveChanges();
        //}

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}
    }
}
