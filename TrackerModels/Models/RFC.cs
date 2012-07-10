using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;




namespace TrackerModels.Models
{
        public class RFC
    {
       
        public int RFCID { get; set; }

        [StringLength(30)]
        public string RFC_No { get; set; }

        [StringLength(500)]
        public string Environment { get; set; }


        public int StatusId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int AppId { get; set; }

        
        public virtual Applications Application { get; set; }

    }
}

   