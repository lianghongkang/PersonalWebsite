using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalWebsite.Models
{
    public class WorkingExperience
    {
        [Key]
        public int Id { get; set; }
        public string WorkingCompany { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Position { get; set; }
        public string Task { get; set; }
        public int WorkingLife { get; set; }
    }
}