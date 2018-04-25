using System;
using System.Collections.Generic;
using System.Text;

namespace cameraatje.Models
{
    public class User
    {
        public string email { get; set; }
        public string password { get; set;}
        public int kleuter_id { get; set; }

        public Toddler toddler { get; set; }
        public int toddler_id { get; set; }

    }
}
