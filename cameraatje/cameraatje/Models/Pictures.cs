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
        public int PictureId { get; set; }
        public int ToddlerId { get; set; }
    }
}
