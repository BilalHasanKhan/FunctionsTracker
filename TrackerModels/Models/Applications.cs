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
            public int ServerId { get; set; }
            public int URLId { get; set; }
            public int StakeHolderMappingId { get; set; }          
            public int OrgId { get; set; }
            public int UserId { get; set; }
           
            
            public virtual ICollection<StakeHoldersDetails> _StakeHoldersDetails { get; set; }
            public virtual ICollection<Users> _Users { get; set; }


            public Applications()
            {
                
                _StakeHoldersDetails = new HashSet<StakeHoldersDetails>();
                _Users = new HashSet<Users>();
            }


            [ForeignKey("ServerId")]
            public virtual ServerDetails serverDetails { get; set; }

            [ForeignKey("URLId")]
            public virtual URLDetails urlDetails { get; set; }

            [ForeignKey("StakeHolderMappingId")]
            public virtual StakeHoldersDetails stakeHoldersDetails { get; set; }

            [ForeignKey("OrgId")]
            public virtual OrgDetails orgDetails { get; set; }

            [ForeignKey("UserId")]
            public virtual Users users { get; set; }
       
    }
}

