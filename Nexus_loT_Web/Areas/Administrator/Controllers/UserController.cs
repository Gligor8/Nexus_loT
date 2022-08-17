using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nexus_loT.DataAccess.Repository;
using Nexus_loT.DataAccess.Repository.IRepository;
using Nexus_loT.Models;
using Nexus_loT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus_loT_Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public UserController(IUserRepository userRepository, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            
            var users = _userRepository.GetAll();
            List<UserVM> usersVM = new List<UserVM>();
            foreach (var user in users)
            {
                var userRole = _userManager.GetRolesAsync(user).GetAwaiter().GetResult();

                

                UserVM userVM = new UserVM()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.PasswordHash,
                    RoleId = userRole.FirstOrDefault(),
                    IsActive = user.IsActive
                };
                usersVM.Add(userVM);
            }

            return View(usersVM);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userFirst = _userRepository.GetById(id);
            UserVM result = new UserVM()
            {
                FirstName = userFirst.FirstName,
                LastName = userFirst.LastName,
                Email = userFirst.Email,
                Password = userFirst.PasswordHash,
                //RoleId = userFirst.RoleId,
                IsActive = userFirst.IsActive
            };
            var userRole = _userManager.GetRolesAsync(userFirst).GetAwaiter().GetResult();
            //string selectedValue = userRole 
            IEnumerable<IdentityRole> getRoles = _roleManager.Roles.ToList();
            ViewBag.RoleId = getRoles.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name,
                Selected = s.Name == userRole[0] ? true : false
            });

            IEnumerable<SelectListItem> items = new List<SelectListItem>(){
                    new SelectListItem {
                        Text = "Active", Value = true.ToString(), Selected = userFirst.IsActive ? true : false
                    },
                    new SelectListItem {
                        Text = "Inactive", Value = false.ToString(), Selected = !userFirst.IsActive ? true : false
                    }
                };
            ViewBag.IsActive = items;

            return View(result);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserVM obj, [FromRoute]string id)
        {

            if (ModelState.IsValid)

            {
                var userFirst = _userRepository.GetById(id);
                
                //var role = _roleManager.Roles.SingleOrDefault(x => x.Name == obj.RoleId);
                //var getRole = _roleManager.GetRoleIdAsync(role);

                var userRole = _userManager.GetRolesAsync(userFirst).GetAwaiter().GetResult();
                var role = _roleManager.FindByNameAsync(userRole.First()).GetAwaiter().GetResult();
                //var userRole = _userManager.IsInRoleAsync(userFirst, obj.RoleId);
                
                var roleById = _roleManager.FindByIdAsync(obj.RoleId).GetAwaiter().GetResult();

                ///////////////
                _userRepository.Edit(obj, id);
               

                if (obj.RoleId != role.Id)
                {
                    //prodolzi ponatamu
                    _userManager.RemoveFromRoleAsync(userFirst, userRole.First()).GetAwaiter().GetResult();
                    _userManager.AddToRoleAsync(userFirst, roleById.Name).GetAwaiter().GetResult();
                }
                
                    
                    
                
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userFromDb = _userRepository.GetById(id);

            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(string id)
        {

            if (ModelState.IsValid)
            {
                _userRepository.Remove(id);
               // _userRepository.Save();

                return RedirectToAction("Index");
            }
            return View();
        }

        //public IActionResult GetUserById(string id)
        //{
        //    return _userRepository.GetById(id);
        //}
    }
}
