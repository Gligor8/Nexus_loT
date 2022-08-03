using Nexus_loT.DataAccess.Repository.IRepository;
using Nexus_loT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.DataAccess.Repository
{
    public class VendorRepository : Repository<Vendor, string>, IVendorRepository
    {
        private readonly ApplicationDbContext _db;
        public VendorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
