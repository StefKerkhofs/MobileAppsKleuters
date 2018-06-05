﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace cameraatje.Models
{
    //Author: Stef Kerkhofs
    public class Toddler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kleuter_id { get; set; }
        public string kleuter_naam { get; set; }
        public string foto_string { get; set; }   
    }
}
