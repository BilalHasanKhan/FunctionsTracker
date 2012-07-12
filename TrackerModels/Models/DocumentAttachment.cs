using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;



namespace TrackerModels.Models
{
    public class DocumentAttachment
    {
        [Key]
        public int DocAttachId { get; set; }

        [StringLength(30)]
        public string DocAttachName { get; set; }

        [StringLength(50)]
        public string DocAttachUiqueName { get; set; }

        [StringLength(50)]
        public string DocAttachPath { get; set; }
        
        [ForeignKey("ACRID")]
        public virtual ACR acr { get; set; }

    }
}
