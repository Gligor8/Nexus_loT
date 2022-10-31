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
    public class Reading : IEntityBase<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [ForeignKey("Sensor")]
        
        public string SensorId { get; set; }
        [Required]
        public Sensor Sensor { get; set; }

        public string Value { get; set; }
        public DateTime DateRead { get; set; } = DateTime.UtcNow;
    }
}
