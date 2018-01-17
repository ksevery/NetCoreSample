using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LiveDemoNetCore.Models;

namespace LiveDemoNetCore.Data
{
    public class ZooContext : DbContext
    {
        public ZooContext (DbContextOptions<ZooContext> options)
            : base(options)
        {
        }

        public DbSet<LiveDemoNetCore.Models.Elephant> Elephant { get; set; }
    }
}
