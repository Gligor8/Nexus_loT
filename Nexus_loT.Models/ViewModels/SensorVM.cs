﻿using System;
using System.Collections.Generic;
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



        [ForeignKey("Cluster")]
        public string ClusterId { get; set; }
        public List<Cluster> Cluster { get; set; }



        [ForeignKey("SensorType")]
        public string SensorTypeId { get; set; }
        public SensorType SensorType { get; set; }

        public string APIUrl { get; set; }

        public double X { get; set; }
        public double Y { get; set; }

        public string Configuration { get; set; }
        public string SerialNumber { get; set; }
        public int Interval { get; set; }
        public bool IsActive { get; set; }
    }
}
