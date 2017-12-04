using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleMvc.Models
{
    public class SampleMvcDataContext : DbContext
    {
        public SampleMvcDataContext() : base("name=SampleMvcDataContext")
        {
        }

        public System.Data.Entity.DbSet<SampleMvc.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<SampleMvc.Models.Location> Locations { get; set; }
    }
}
