using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PersonalWebsite.Models
{
    public class PersonalInformation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public bool Marriage { get; set; }
        [Required]
        [StringLength(11)]
        public string Tel { get; set; }
        public string ResidentialAddress  { get; set; }
        public string NativePlace { get; set; }
        public string Email { get; set; }
        public string QQ { get; set; }
        public string Wechat { get; set; }


    }
}