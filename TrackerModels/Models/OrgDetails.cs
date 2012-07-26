using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TrackerModels.Models
{
    public class OrgDetails
    {
        [Key]
        public int OrgId { get; set; }

        public string Segment { get; set; }

        
    }
}
