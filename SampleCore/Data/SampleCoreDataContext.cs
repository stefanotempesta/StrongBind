using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleCore.Models;

namespace SampleCore.Models
{
    public class SampleCoreDataContext : DbContext
    {
        public SampleCoreDataContext (DbContextOptions<SampleCoreDataContext> options)
            : base(options)
        {
        }

        public DbSet<SampleCore.Models.Person> Person { get; set; }

        public DbSet<SampleCore.Models.Location> Location { get; set; }
    }
}
