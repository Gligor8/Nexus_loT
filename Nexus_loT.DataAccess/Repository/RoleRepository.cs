using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nexus_loT.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.DataAccess.Repository
{
    //public class RoleRepository : Repository<IdentityRole>, IRoleRepository
    //{
    //    private readonly ApplicationDbContext _db;

    //    public RoleRepository(ApplicationDbContext db) : base(db)
    //    {
    //        _db = db;
    //    }
    //    public void Add(IdentityRole entity)
    //    {
    //        _db.Roles.Add(entity);
    //        _db.SaveChanges();
    //    }

    //    public void Edit(IdentityRole entity)
    //    {
    //        _db.Roles.Update(entity);
    //        _db.SaveChanges();
    //    }

    //    public IEnumerable<IdentityRole> GetAll()
    //    {
    //        return _db.Roles.ToList();
    //    }

    //    public IdentityRole GetById(string id)
    //    {
    //        return _db.Roles.AsNoTracking()
    //            .SingleOrDefault(x => x.Id == id);
    //    }

    //    public void Remove(string id)
    //    {
    //        IdentityRole role = _db.Roles.SingleOrDefault(x => x.Id == id);
    //        _db.Roles.Remove(role);
    //        _db.SaveChanges();
    //    }

        
    //}
}
