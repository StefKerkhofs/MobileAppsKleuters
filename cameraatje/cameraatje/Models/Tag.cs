using System;
using System.Collections.Generic;
using System.Text;

namespace cameraatje.Models
{
    public class Tag
    {
        public int foto_id { get; set; }
        public int tagged_kleuter_id { get; set; }
        public Toddler toddler { get; set; }

    }
}
