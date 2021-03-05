using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PersonalWebsite.Models
{
    public class PersonalDbContext : DbContext
    {
        public PersonalDbContext() : base("name=CodeFirstDbContext")
        {

        }
        public DbSet<PersonalInformation> infos { set; get; }
        public DbSet<WorkingExperience> work { get; set; }
        public DbSet<LearningExperience> school { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}