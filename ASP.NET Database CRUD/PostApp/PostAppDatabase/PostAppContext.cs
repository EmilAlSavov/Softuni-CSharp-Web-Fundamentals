using Microsoft.EntityFrameworkCore;
using PostAppDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostAppDatabase
{
    public class PostAppContext : DbContext
    {
        public PostAppContext(DbContextOptions<PostAppContext> options)
            : base(options)
        {
          
        }

        public DbSet<Post> Posts { get; set; }
    }
}
