using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TrackerModels.Models
{
   public class ServiceRequestMapping
    {
       [Key]
       public int RequestMappingId { get; set; }
       [MaxLength(50)]
       public string RemedyNumber { get; set; }
       public bool IsAttachedToACR { get; set; }

    }
}
