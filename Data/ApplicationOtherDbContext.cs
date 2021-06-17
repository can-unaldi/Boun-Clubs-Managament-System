using BounClubs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BounClubs.Data
{
    public class ApplicationOtherDbContext : DbContext
    {
        public ApplicationOtherDbContext(DbContextOptions<ApplicationOtherDbContext> options)
            : base(options)
        {

        }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Event> Events { get; set; }


    }
}
