using Nexus_loT.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.DataAccess.Repository
{
    public class IdClass : IEntity<string>
    {
        public string Id { get ; set ; }
    }
}
