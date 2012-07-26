using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace TrackerModels.Models
{
    public class AssetDetails
    {
        [Key]
        public int AssetId { get; set; }

        [Required]
        [MaxLength(200)]
        public string AssetName { get; set; }


    }
}
