using Nexus_loT.Models;
using Nexus_loT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.DataAccess.Repository.IRepository
{
    public interface ISensorRepository 
    {
        void Add(SensorVM entity);
        void Edit(SensorVM entity, string id);
        Sensor GetById(string id);
        IEnumerable<Sensor> GetAll(Expression<Func<Sensor, bool>>? filter = null, string? includeProperties = null);
        void Remove(SensorVM entity, string id);
    }
}
