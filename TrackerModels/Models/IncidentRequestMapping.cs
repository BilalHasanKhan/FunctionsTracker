using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerModels.Models
{
    public class IncidentRequestMapping
    {
       [Key]
        public int IncidentRequestId { get; set; }
        public int RemedyNo { get; set; }
        public int AppId{ get; set; }

        [ForeignKey("AppId")]
        public Applications Application { get; set; }
    }
}
