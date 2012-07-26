using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrackerModels.Models
{
   public class ServerAppMapping
    {
       [Key]
       public int AppMappingId { get; set; }
       public int ServerId { get; set; }
       public int AppId { get; set; }

       [ForeignKey("ServerId")]
       public virtual ServerDetails serverDetails { get; set; }
       [ForeignKey("AppId")]
       public virtual Applications application { get; set; }
    }
}
