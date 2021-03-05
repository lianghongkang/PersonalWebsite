using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalWebsite.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string ImageUrl { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
    }
}