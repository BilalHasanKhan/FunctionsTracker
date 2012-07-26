using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerModels.Models
{
    public class ServerDetails
    {
        [Key]
        public int ServerId { get; set; }

        [Required] [MaxLength(100)]
        public string ServerName { get; set; }

        public bool IsActive { get; set; }

        public int ServerTypeId { get; set; }

        public virtual List<ServerAppMapping> serverAppMapping { get; set; }

    }
}
