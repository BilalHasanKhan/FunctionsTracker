using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace TrackerModels.Models
{
   public class URLDetails
    {
       [Key]
       public int URLId { get; set; }

       [Required]
       [DataType(DataType.Url)]
       public string Url { get; set; }

    }
}
