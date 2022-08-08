
using PlanTechShenApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;

namespace PlanTechShenWebApi.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Detection")]
    public class Detection
    {
      
        [Required]
        [Key]
        public int DetectionId { get; set; }

        public int DeviceId { get; set; }
            public DateTime DetectionDate { get; set; }
            public double WaterLevelPercentage { get; set; }



     



       


    }
}
