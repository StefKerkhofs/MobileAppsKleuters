using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace cameraatje.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }
        public string email { get; set; }
        public string password { get; set;}
        public int kleuter_id { get; set; }

        public Toddler Toddler { get; set; }
        public int toddler_id { get; set; }

    }
}
