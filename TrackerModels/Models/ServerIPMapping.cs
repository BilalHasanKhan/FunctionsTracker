using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackerModels;

namespace TrackerModels.Models
{
    public class ServerIPMapping
    {
        [Key]
        public int ID { get; set; }
        
        public int ServerDetailsID { get; set; }
        public bool IsInternalExternal { get; set; }
        public string IPAddress {get; set;}

        [ForeignKey("ServerDetailsID")]
        public virtual ServerDetails ServerDetails { get; set; }
    }
}
