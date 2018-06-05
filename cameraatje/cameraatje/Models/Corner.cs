using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace cameraatje.Models
{
    //Author: Stef Kerkhofs
    public class Corner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int hoek_id { get; set; }
        public string hoek_naam { get; set; }
        [ForeignKey("foto_string")]
        public string foto_string { get; set; }

       

    }
}
