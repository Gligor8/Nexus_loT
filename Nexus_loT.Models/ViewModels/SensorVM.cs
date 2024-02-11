using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.Models.ViewModels
{
    public class SensorVM
    {
        public string Id { get; set; }
        public string Name { get; set; }


        public IEnumerable<Cluster> Clusters { get; set; }



        [ForeignKey("SensorType")]
        public string SensorTypeId { get; set; }
        public SensorType SensorType { get; set; }

        [Display(Name = "API Url")]
        public string APIUrl { get; set; }

        public double X { get; set; }
        public double Y { get; set; }

        public string Configuration { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        public int Interval { get; set; }
        public bool IsActive { get; set; }
    }
}
