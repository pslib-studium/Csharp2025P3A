using c01EFC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c01EFC.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
