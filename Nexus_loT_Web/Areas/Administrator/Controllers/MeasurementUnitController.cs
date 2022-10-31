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
    public class MeasurementUnitController : Controller
    {
        private readonly IMeasurementUnitRepository _measurementUnitRepository;
        
        public MeasurementUnitController(IMeasurementUnitRepository measurementUnitRepository)
        {
            _measurementUnitRepository = measurementUnitRepository;
            
        }

        //[HttpGet]
        public IActionResult Index()
        {
            IEnumerable<MeasurementUnit> ListOfMeasurementUnits = _measurementUnitRepository.GetAll();
            return View(ListOfMeasurementUnits);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MeasurementUnit obj)
        {
            if (ModelState.IsValid)
            {
                _measurementUnitRepository.Add(obj);
              
               
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
            var measurementUnitFirst = _measurementUnitRepository.GetById(id);

            return View(measurementUnitFirst);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MeasurementUnit obj, [FromRoute] string id)
        {

            if (ModelState.IsValid)
            {
                _measurementUnitRepository.Edit(obj, id);
               
                
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
            var measurementUnitFromDb = _measurementUnitRepository.GetById(id);

            if (measurementUnitFromDb == null)
            {
                return NotFound();
            }

            return View(measurementUnitFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("Delete")]
        public IActionResult DeletePOST(string id)
        {

            if (ModelState.IsValid)
            {
                _measurementUnitRepository.Remove(id);
               

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
