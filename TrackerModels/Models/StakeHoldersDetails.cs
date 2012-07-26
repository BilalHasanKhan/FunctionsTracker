using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace TrackerModels.Models
{
   public class StakeHoldersDetails
    {
        [Key]
        public int StakeHolderId { get; set; }

        [Required][MaxLength(100)]  
        public string  FirstName { get; set; }

        [Required]
        [MaxLength(100)] 
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        public List<StakeHolderMapping> StakeHolderMappings { get; set; }

    }
}
