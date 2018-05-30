using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace cameraatje.Models
{
    class Pictures
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int count { get; set; }
        [ForeignKey("foto_id")]
        public int foto_id { get; set; }
        [ForeignKey("kleuter_id")]
        public int kleuter_id { get; set; }
    }
}
