using Nexus_loT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.DataAccess.Repository.IRepository
{
    public interface IClusterRepository : IRepository<Cluster, string>
    {
        //Cluster GetById(string id);
    }
}
