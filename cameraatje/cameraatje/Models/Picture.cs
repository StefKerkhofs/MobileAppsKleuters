using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace cameraatje.Models
{
    public class Picture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int foto_id { get; set; }
        public string foto_string { get; set; }
        [ForeignKey("kleuter_id")]
        public int kleuter_id { get; set; }

        [ForeignKey("hoek_id")]
        public int hoek_id { get; set; }
        public string opmerking { get; set; }
        public string label { get; set; }
     

       


    }
}
