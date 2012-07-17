using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerModels.Models
{
   public  class AssigneeMapping
    {
       public int AssigneeMappingId { get; set; }
       public int UserId { get; set; }
       public int ACRId { get; set; }

       [ForeignKey("UserId")]
       public Users User { get; set; }

       [ForeignKey("ACRId")]
       public ACR Acr { get; set; }

    }
}
