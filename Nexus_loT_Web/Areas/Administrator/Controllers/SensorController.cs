//using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
   
    public class SensorController : Controller
    {
        private readonly ISensorRepository _sensorRepository;
        private readonly ISensorTypeRepository _sensorTypeRepository;
        private readonly IClusterRepository _clusterRepository;
        //private readonly IMapper _mapper;
        public SensorController(ISensorRepository sensorRepository, ISensorTypeRepository sensorTypeRepository, IClusterRepository clusterRepository)
        {
            _sensorRepository = sensorRepository;
            _sensorTypeRepository = sensorTypeRepository;
            _clusterRepository = clusterRepository;
            //_mapper = mapper;

        }
        public IActionResult Index()
        {
            var sensors = _sensorRepository.GetAll();
            List<SensorVM> sensorsVM = new List<SensorVM>();
            foreach (var sensor in sensors)
            {

                SensorVM sensorVM = new SensorVM()
                {
                    Id = sensor.Id,
                    Name = sensor.Name,
                    APIUrl = sensor.APIUrl,
                    Configuration = sensor.Configuration,
                    SensorTypeId = sensor.SensorTypeId,
                    SensorType = sensor.SensorType,
                    ClusterId = sensor.ClusterId,
                    Cluster = sensor.Cluster,
                    X = sensor.X,
                    Y = sensor.Y,
                    SerialNumber = sensor.SerialNumber,
                    Interval = sensor.Interval,
                    IsActive = sensor.IsActive
                };
                sensorsVM.Add(sensorVM);
            }
            return View(sensorsVM);
        }

        [HttpGet]
        public IActionResult Add()
        {
            IEnumerable<Cluster> getClusters = _clusterRepository.GetAll().ToList();
            ViewData["Cluster"] = new SelectList(getClusters.ToList(), "Id", "Name");

            IEnumerable<SensorType> getSensorTypes = _sensorTypeRepository.GetAll().ToList();
            ViewData["SensorType"] = new SelectList(getSensorTypes.ToList(), "Id", "Name");

            IEnumerable<SelectListItem> items = new List<SelectListItem>(){
                    new SelectListItem {
                        Text = "Active", Value = true.ToString()
                    },
                    new SelectListItem {
                        Text = "Inactive", Value = false.ToString()
                    }
                };
            ViewBag.IsActive = items;

            return View();
        }

        [HttpPost]
        public IActionResult Add(SensorVM obj)
        {
            if (ModelState.IsValid)
            {
                //var sensor = _sensorRepository.GetById(id);
                //SensorVM sensorVM = new SensorVM()
                //{
                //    Id = sensor.Id,
                //    Name = sensor.Name,
                //    APIUrl = sensor.APIUrl,
                //    SensorTypeId = sensor.SensorTypeId,
                //    SensorType = sensor.SensorType,
                //    ClusterId = sensor.ClusterId,
                //    Cluster = sensor.Cluster,
                //    X = sensor.X,
                //    Y = sensor.Y,
                //};
                //var mappedSensor = _mapper.Map<SensorVM>(obj);

                _sensorRepository.Add(obj);


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
            var sensorFirst = _sensorRepository.GetById(id);

            SensorVM sensorVM = new SensorVM()
            {
                Id = sensorFirst.Id,
                Name = sensorFirst.Name,
                APIUrl = sensorFirst.APIUrl,
                Configuration = sensorFirst.Configuration,
                SensorTypeId = sensorFirst.SensorTypeId,
                SensorType = sensorFirst.SensorType,
                ClusterId = sensorFirst.ClusterId,
                Cluster = sensorFirst.Cluster,
                X = sensorFirst.X,
                Y = sensorFirst.Y,
                SerialNumber = sensorFirst.SerialNumber,
                Interval = sensorFirst.Interval,
                IsActive = sensorFirst.IsActive
            };

            IEnumerable<Cluster> clusters = _clusterRepository.GetAll();
            ViewBag.Cluster = clusters.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name,
                //Selected = s.Unit == units[0] ? true : false
            });

            IEnumerable<SensorType> sensorTypes = _sensorTypeRepository.GetAll();
            ViewBag.SensorType = sensorTypes.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name,
                //Selected = s.Unit == units[0] ? true : false
            });

            IEnumerable<SelectListItem> items = new List<SelectListItem>(){
                    new SelectListItem {
                        Text = "Active", Value = true.ToString(), Selected = sensorVM.IsActive ? true : false
                    },
                    new SelectListItem {
                        Text = "Inactive", Value = false.ToString(), Selected = !sensorVM.IsActive ? true : false
                    }
                };
            ViewBag.IsActive = items;
            return View(sensorVM);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SensorVM obj, [FromRoute] string id)
        {

            if (ModelState.IsValid)
            {
                _sensorRepository.Edit(obj, id);


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
            var sensorFromDb = _sensorRepository.GetById(id);

            SensorVM sensorVM = new SensorVM()
            {
                Id = sensorFromDb.Id,
                Name = sensorFromDb.Name,
                APIUrl = sensorFromDb.APIUrl,
                Configuration = sensorFromDb.Configuration,
                SensorTypeId = sensorFromDb.SensorTypeId,
                SensorType = sensorFromDb.SensorType,
                ClusterId = sensorFromDb.ClusterId,
                Cluster = sensorFromDb.Cluster,
                X = sensorFromDb.X,
                Y = sensorFromDb.Y,
                SerialNumber = sensorFromDb.SerialNumber,
                Interval = sensorFromDb.Interval,
                IsActive = sensorFromDb.IsActive
            };

            if (sensorVM == null)
            {
                return NotFound();
            }

            return View(sensorVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("Delete")]
        public IActionResult DeletePOST(string id)
        {

            if (ModelState.IsValid)
            {
                _sensorRepository.Remove(id);


                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
