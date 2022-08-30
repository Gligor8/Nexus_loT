using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nexus_loT.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus_loT_Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleRepository)
        {
            _roleManager = roleRepository;

        }
        public IActionResult Index()
        {
            //IEnumerable<IdentityRole> ListOfRoles = _roleRepository.GetAll();
            
            return View(_roleManager.Roles);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IdentityRole obj)
        {
            if (ModelState.IsValid)
            {
               await _roleManager.CreateAsync(obj);
               // _roleRepository.Add(obj);
                //_roleRepository.Save();
                
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var RoleFromDb = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();

            if (RoleFromDb == null)
            {
                return NotFound();
            }

            return View(RoleFromDb);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IdentityRole obj)
        {

            if (ModelState.IsValid)
            {
                var RoleFromDb = await _roleManager.FindByIdAsync(obj.Id);
                RoleFromDb.Name = obj.Name;
                var role = await _roleManager.UpdateAsync(RoleFromDb);
                //_roleRepository.Edit(obj);
                //_roleRepository.Save();

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
            var RoleFromDb = _roleManager.Roles.Where(x=>x.Id == id).FirstOrDefault();

            if (RoleFromDb == null)
            {
                return NotFound();
            }

            return View(RoleFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(IdentityRole obj)
        {

            if (ModelState.IsValid)
            {
                var RoleFromDb = await _roleManager.FindByIdAsync(obj.Id);
                RoleFromDb.Name = obj.Name;
                var role = await _roleManager.DeleteAsync(RoleFromDb);

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
