using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerModels.Models
{
   public class ServerAppMapping
    {
       public int AppMappingId { get; set; }
       public int ServerId { get; set; }
       public int AppId { get; set; }

       [ForeignKey("ServerId")]
       public virtual ServerDetails serverDetails { get; set; }
       [ForeignKey("AppId")]
       public virtual Applications application { get; set; }
    }
}
