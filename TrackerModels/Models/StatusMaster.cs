using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace TrackerModels.Models
{
   public class StatusMaster
    {
      
        [Key]
        public int StatusId { get; set; }

        [MaxLength(30)]
        public string StatusName{ get; set; }

        public bool IsActive { get; set; }
    }
}
