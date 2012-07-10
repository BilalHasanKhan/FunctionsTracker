using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TrackerModels.Models
{
    public class StakeHolderMaster
    {
        [Key]
        public int ID{get;set;}

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }


        public int OrgID { get; set; }
        
        public int RoleID { get; set; }

        public bool IsActive { get; set; }

    }
}
