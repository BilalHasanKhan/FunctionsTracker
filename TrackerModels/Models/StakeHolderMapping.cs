using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TrackerModels.Models
{
    public class StakeHolderMapping
    {
        [Key]
        public int MapID { get; set; }
        
        public int ACRID { get; set; }

        public int StakeHolderID { get; set; }

        [ForeignKey("ACRID")]
        public virtual ACR ACR { get; set; }

        [ForeignKey("StakeHolderID")]
        public virtual StakeHoldersDetails StakeHoldersDetails { get; set; }
    }
}
