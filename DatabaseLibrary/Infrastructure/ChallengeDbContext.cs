using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary.Conrete.Entities;

namespace DatabaseLibrary.Infrastructure
{
    public class ChallengeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ChallengeDbContext() : base("ChallengeDbContextConnectionString")
        {
        }
    }
}
