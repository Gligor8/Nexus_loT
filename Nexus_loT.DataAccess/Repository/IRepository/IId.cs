using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.DataAccess.Repository.IRepository
{
    public interface IEntity<TId> where TId : class
    {
        TId Id { get; set; }
    }
}
