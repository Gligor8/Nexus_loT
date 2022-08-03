using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexus_loT.DataAccess.Repository.IRepository;
using Nexus_loT.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.DataAccess.Repository
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class, IEntityBase<TId> where TId : IEquatable<TId>
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<TEntity> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
            _db.SaveChanges();
        }

        public void Edit(TEntity entity, TId id)
        {
            dbSet.Update(entity);
            _db.SaveChanges();
        }

        //public void Edit(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet;
        }

        public TEntity GetById(TId id)
        {
            return _db.Set<TEntity>()
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Remove(TId id)
        {
            TEntity entity = dbSet.SingleOrDefault(x => x.Id.Equals(id));
            dbSet.Remove(entity);
            _db.SaveChanges();
        }
    }
}
