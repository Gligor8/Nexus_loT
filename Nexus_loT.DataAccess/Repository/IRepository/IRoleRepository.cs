using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.DataAccess.Repository.IRepository
{
    public interface IRoleRepository : IRepository<IdentityRole, string>
    {
       // void Edit(IdentityRole entity);
       //// public void Save();
       // IdentityRole GetById(string id);
    }
}
