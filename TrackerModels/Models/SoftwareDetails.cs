using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace TrackerModels.Models
{
    public class SoftwareDetails
    {
        [Key]
        public int SoftwareId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Software { get; set; }
    }
}
