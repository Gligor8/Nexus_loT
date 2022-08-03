using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.DataAccess.Repository.IRepository
{
    public interface IRepository<TEntity,TId> where TEntity : class where TId : IEquatable<TId> 
    {
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        void Remove(TId id);
        void Edit(TEntity entity, TId id);
        
        TEntity GetById(TId id);

        
    }
}
