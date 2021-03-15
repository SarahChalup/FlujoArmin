﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIProductor.Models
{
    public class Data
    {
        [Key]
        public String NameDevice { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EventDate{ get; set; }
        [Required]
        public String Event { get; set; }

    }
}
