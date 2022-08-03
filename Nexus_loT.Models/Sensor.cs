using Nexus_loT.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus_loT.Models
{
    public class Sensor : IEntityBase<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
