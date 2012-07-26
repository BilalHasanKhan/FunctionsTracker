using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerModels.Models
{
    public class Applications
    {
            [Key]
            public int AppId { get; set; }
            
            [MaxLength(30)]
            public string AppName { get; set; }

            [MaxLength(20)]
            public string AppInstance { get; set; }


            [MaxLength(10)]
            public string CMDBRefNum { get; set; }

           
            public int SLALevel { get; set; }    
            public int URLId { get; set; }
           // public int StakeHolderMappingId { get; set; }          
            public int OrgId { get; set; }
           // public int UserId { get; set; }
           
            
            public virtual ICollection<StakeHoldersDetails> StakeHoldersDetails { get; set; }
            public virtual ICollection<Users> Users { get; set; }


            public Applications()
            {
                
                StakeHoldersDetails = new HashSet<StakeHoldersDetails>();
                Users = new HashSet<Users>();
            }



            [ForeignKey("URLId")]
            public virtual URLDetails urlDetails { get; set; }

            //[ForeignKey("StakeHolderMappingId")]
            //public virtual StakeHoldersDetails stakeHoldersDetails { get; set; }

            [ForeignKey("OrgId")]
            public virtual OrgDetails orgDetails { get; set; }

            //[ForeignKey("UserId")]
            //public virtual Users users { get; set; }
       
    }
}

