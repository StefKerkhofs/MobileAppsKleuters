using System;
using System.Collections.Generic;
using System.Text;

namespace cameraatje.Models
{
   public class Toddler
    {
        public int kleuter_id { get; set; }
        public int foto_id { get; set; }
        public string kleuter_naam { get; set; }
        public string foto_string { get; set; }

        public int kleuter_id_referentie { get; set; }
        public User user { get; set; }

        public int tagged_kleuter_id { get; set; }
        public Tag tag { get; set; }
        
    }
}
