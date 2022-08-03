using Microsoft.AspNetCore.Mvc;
using Nexus_loT.DataAccess.Repository.IRepository;
using Nexus_loT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus_loT_Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class VendorController : Controller
    {
        
        private readonly IVendorRepository _vendorRepository;

        public VendorController(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;

        }
        public IActionResult Index()
        {
            IEnumerable<Vendor> ListOfVendors = _vendorRepository.GetAll();
            return View(ListOfVendors);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Vendor obj)
        {
            if (ModelState.IsValid)
            {
                _vendorRepository.Add(obj);
                

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
            var vendorFirst = _vendorRepository.GetById(id);

            return View(vendorFirst);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Vendor obj, [FromRoute] string id)
        {

            if (ModelState.IsValid)
            {
                _vendorRepository.Edit(obj, id);
                

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
            var vendorFromDb = _vendorRepository.GetById(id);

            if (vendorFromDb == null)
            {
                return NotFound();
            }

            return View(vendorFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("Delete")]
        public IActionResult DeletePOST(string id)
        {

            if (ModelState.IsValid)
            {
                _vendorRepository.Remove(id);
                

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
