using Nexus_loT.DataAccess.Repository.IRepository;
using Nexus_loT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nexus_loT.DataAccess.Repository
{
    public class ClusterRepository : Repository<Cluster, string>, IClusterRepository
    {
        private readonly ApplicationDbContext _db;
        public ClusterRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        
        //public void Add(Cluster entity)
        //{
        //    _db.Clusters.Add(entity);
        //    //_db.SaveChanges();
        //}

        //public void Edit(Cluster entity)
        //{
        //    _db.Clusters.Update(entity);
        //    _db.SaveChanges();
        //}

        //public IEnumerable<Cluster> GetAll()
        //{
        //    return _db.Clusters.ToList();
        //}

        //public Cluster GetById(string id)
        //{
        //    return _db.Clusters
        //        .SingleOrDefault(x => x.Id == id);
        //}

        //public void Remove(string id)
        //{
        //    Cluster sensorLookupTable = _db.Clusters.SingleOrDefault(x => x.Id == id);
        //    _db.Clusters.Remove(sensorLookupTable);
        //    _db.SaveChanges();
        //}

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}
    }
}
