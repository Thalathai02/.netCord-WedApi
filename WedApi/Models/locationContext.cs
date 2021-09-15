using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WedApi.Models
{
    public class locationContext : DbContext
    {
        public locationContext(DbContextOptions<locationContext> options)
            : base(options)
        {
        }

        public DbSet<location> locations { get; set; }
        public DbSet<user> users { get; set; }
        
    }
}

