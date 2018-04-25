using System;
using System.Collections.Generic;
using System.Text;

namespace cameraatje.Models
{
    public class Picture
    {
        public int foto_id { get; set; }
        public string foto_string { get; set; }
        public int kleuter_id { get; set; }
        public int hoek_id { get; set; }

        public string opmerking { get; set; }
        public string label { get; set; }
        public Tag tag { get; set; }

        
    }
}
