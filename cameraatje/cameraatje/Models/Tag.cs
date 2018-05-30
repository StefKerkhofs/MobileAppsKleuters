using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace cameraatje.Models
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int foto_id { get; set; }
        public int tagged_kleuter_id { get; set; }
        public Toddler Toddler { get; set; }
        public Picture Picture { get; set; }

       // public ICollection<Picture> Pictures { get; set; }
    }
}
