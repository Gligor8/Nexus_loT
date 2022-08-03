using Nexus_loT.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.Models
{
    public class SensorType : IEntityBase<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("MeasurementUnit")]
        public string MeasurementUnitId { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }

        public string APIUrl { get; set; }

        public string Configuration { get; set; }


        [ForeignKey("Vendor")]       
        public string VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
