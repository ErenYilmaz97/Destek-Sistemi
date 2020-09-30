using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities.Dbcontext
{
    public class AppDbContext : IdentityDbContext<User,Role,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Petition> Petitions { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<City> Cities { get; set; } 

    }
}
