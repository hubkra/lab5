using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace lab5.Models
{
    public class aspNetlab5Context : DbContext
    {
        public aspNetlab5Context(DbContextOptions<aspNetlab5Context> options)
            : base(options)
        {
        }

        public DbSet<aspNetlab5Item> aspNetlab5 { get; set; }

    }
}
