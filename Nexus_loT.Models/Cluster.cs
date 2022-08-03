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
    public class Cluster : IEntityBase<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("Sensor")]
        public string SensorId { get; set; }
        public List<Sensor> Sensor { get; set; }


    }
}
