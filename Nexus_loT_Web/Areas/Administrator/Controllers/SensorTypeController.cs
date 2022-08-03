using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nexus_loT.DataAccess.Repository.IRepository;
using Nexus_loT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus_loT_Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SensorTypeController : Controller
    {
        private readonly ISensorTypeRepository _sensorTypeRepository;
        private readonly IMeasurementUnitRepository _measurementUnitRepository;
        private readonly IVendorRepository _vendorRepository;

        public SensorTypeController(ISensorTypeRepository sensorTypeRepository, IMeasurementUnitRepository measurementUnitRepository, IVendorRepository vendorRepository)
        {
            _sensorTypeRepository = sensorTypeRepository;
            _measurementUnitRepository = measurementUnitRepository;
            _vendorRepository = vendorRepository;
        }
        public IActionResult Index()
        {
            var sensorTypes = _sensorTypeRepository.GetAll();
            var vendors = _vendorRepository.GetAll().FirstOrDefault();
            return View(sensorTypes);
        }

        [HttpGet]
        public IActionResult Add()
        {
            IEnumerable<MeasurementUnit> getMUnits = _measurementUnitRepository.GetAll().ToList();
            ViewData["MeasurementUnit"] = new SelectList(getMUnits.ToList(), "Id", "Symbol");

            IEnumerable<Vendor> getVendors = _vendorRepository.GetAll().ToList();
            ViewData["Vendor"] = new SelectList(getVendors.ToList(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Add(SensorType obj)
        {
            if (ModelState.IsValid)
            {
                _sensorTypeRepository.Add(obj);


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
            var sensorTypeFirst = _sensorTypeRepository.GetById(id);
            
            IEnumerable<MeasurementUnit> units = _measurementUnitRepository.GetAll();
            ViewBag.MeasurementUnit = units.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Symbol,
                //Selected = s.Unit == units[0] ? true : false
            });

            IEnumerable<Vendor> vendors = _vendorRepository.GetAll();
            ViewBag.Vendor = vendors.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name,
                //Selected = s.Unit == units[0] ? true : false
            });

            return View(sensorTypeFirst);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SensorType obj, [FromRoute] string id)
        {

            if (ModelState.IsValid)
            {
                _sensorTypeRepository.Edit(obj, id);


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
            var sensorTypeFromDb = _sensorTypeRepository.GetById(id);

            if (sensorTypeFromDb == null)
            {
                return NotFound();
            }

            return View(sensorTypeFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("Delete")]
        public IActionResult DeletePOST(string id)
        {

            if (ModelState.IsValid)
            {
                _sensorTypeRepository.Remove(id);


                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
