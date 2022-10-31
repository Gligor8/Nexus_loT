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
    public class ClusterController : Controller
    {
        private readonly IClusterRepository _clusterRepository;
        
        public ClusterController(IClusterRepository clusterRepository)
        {
            _clusterRepository = clusterRepository;
            
        }

        //[HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Cluster> ListOfClusters = _clusterRepository.GetAll();
            return View(ListOfClusters);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Cluster obj)
        {
            if (ModelState.IsValid)
            {
                _clusterRepository.Add(obj);
                
               
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
            var clusterFirst = _clusterRepository.GetById(id);

            return View(clusterFirst);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cluster obj, [FromRoute] string id)
        {

            if (ModelState.IsValid)
            {
                _clusterRepository.Edit(obj, id);
               
                
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
            var clusterFromDb = _clusterRepository.GetById(id);

            if (clusterFromDb == null)
            {
                return NotFound();
            }

            return View(clusterFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("Delete")]
        public IActionResult DeletePOST(string id)
        {

            if (ModelState.IsValid)
            {
                _clusterRepository.Remove(id);
                

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
