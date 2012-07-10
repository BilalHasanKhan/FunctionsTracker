using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerModels.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [MaxLength(15)]
        public string FirstName { get; set; }

        [MaxLength(15)]
        public string LastName { get; set; }

        
        public int EmpID { get; set; }

        [MaxLength(6)]
        public string NTID { get; set; }

        [MaxLength(30)]
        public string BPEmailID { get; set; }

        public bool IsActive { get; set; }


        public long Contact1 { get; set; }
        public long Contact2 { get; set; }

        [MaxLength(15)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        [MaxLength(15)]
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public int AssetID { get; set; }

        public int SoftwareMappingID { get; set; }

        [ForeignKey("AssetID")]
        public virtual AssetDetails Assetdetails { get; set; }

        [ForeignKey("SoftwareMappingID")]
        public virtual SoftwareDetails Softwaredetails { get; set; } 
    }

}
