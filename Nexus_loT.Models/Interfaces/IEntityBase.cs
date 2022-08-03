using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.Models.Interfaces
{
    public interface IEntityBase<TId> where TId : IEquatable<TId>
    {
        TId Id { get; set; }
    }

}
