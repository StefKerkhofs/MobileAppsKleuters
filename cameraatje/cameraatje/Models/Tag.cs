using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace cameraatje.Models
{
    //Author: Stef Kerkhofs
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int foto_id { get; set; }
        [ForeignKey("kleuter_id")]
        public int tagged_kleuter_id { get; set; }
     


    }
}
