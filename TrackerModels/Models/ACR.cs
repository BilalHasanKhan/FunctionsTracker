using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace TrackerModels.Models
{
    public class ACR
    {
        [Key]
        public int ACRID { get; set; }

        [StringLength(30)]
        public string ACR_Name { get; set; }

        [StringLength(500)]
        public string Summary { get; set; }

        public int ApplicationId { get; set; }

        public int RaisedBy { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double EstimatedEfforts { get; set; }

        public int StatusId { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ApprovedBy { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool isActive { get; set; }

        [ForeignKey("ApplicationId")]
        public virtual Applications Application { get; set; }

        [ForeignKey("StatusId")]
        public virtual StatusMaster Status { get; set; }

        
        public virtual List<AssigneeMapping> AssigneeMappings { get; set; }

    }
}
