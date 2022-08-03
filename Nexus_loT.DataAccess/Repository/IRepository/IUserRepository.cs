using Nexus_loT.Models;
using Nexus_loT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.DataAccess.Repository.IRepository
{
    public interface IUserRepository 
    {
        void Edit(UserVM entity, string id);
        //public void Save();
        User GetById(string id);
        IEnumerable<User> GetAll();
        void Remove(string id);
    }
}
