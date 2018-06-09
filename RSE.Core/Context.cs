using RSE.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSE.Core
{
    class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public Context () : base ("TeamDB")
        { }

        public Context(DbSet<Exercise> exercises)
        {
            Exercises = exercises;
        }
    }
}
