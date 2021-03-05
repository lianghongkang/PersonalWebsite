using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalWebsite.Models
{
    public class LearningExperience
    {
        [Key]
        public int Id { get; set; }
        public string School { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
    }
}