using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Nexus_loT.DataAccess.Repository.IRepository;
using Nexus_loT.Models;
using Nexus_loT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.DataAccess.Repository
{
    public class UserRepository : IUserRepository 
    {
        private readonly ApplicationDbContext _db;
        
        public UserRepository(ApplicationDbContext db) 
        {
            _db = db;
            //_mapper = mapper;
        }
        public void Add(UserVM entity)
        {

            //_db.Users.Add(entity);
        }

        public void Edit(UserVM userVM, string id)
        {
            var originalUser = _db.Users.FirstOrDefault(x => x.Id == id);

            
            var userFromDb = _db.Users.FirstOrDefault(x => x.Email == userVM.Email);


            originalUser.FirstName = userVM.FirstName;
            originalUser.LastName = userVM.LastName;
            
            //originalUser.Password = userFirst.PasswordHash,
            //RoleId = userFirst.RoleId;
            originalUser.IsActive = userVM.IsActive;

          

            if (userFromDb == null && userVM.Email != null)
            {
                //prodolzi ponatamu
                originalUser.Email = userVM.Email;
            }
            else
            {
                if (id == userFromDb.Id)
                {
                    // prodolzi ponatamu
                }
                else
                {
                    throw new Exception("This email already exists!");   
                }
            }

            if (userVM.Password != null)
            {
                var password = new PasswordHasher<UserVM>();
                var hashed = password.HashPassword(userVM, userVM.ConfirmPassword);
                originalUser.PasswordHash = hashed;

            }
            else 
            {
                originalUser.PasswordHash = originalUser.PasswordHash;
                //throw new Exception("Password field cannot be left blank!!");
            }

            


            _db.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = _db.Users.ToList();
            //List<UserVM> mappedUsers = _mapper.Map<List<UserVM>>(users);
            return users;
        }

        

        public User GetById(string id)
        {

            return _db.Users.SingleOrDefault(x => x.Id == id);
        }

        public void Remove(string id)
        {
            User user = _db.Users.SingleOrDefault(x => x.Id == id);

            _db.Users.Remove(user);
            _db.SaveChanges();
        }

       
    }
}
