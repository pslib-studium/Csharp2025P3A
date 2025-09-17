using c01EFC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace c01EFC.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        //public static readonly ILoggerFactory MyLoggerFactory
        //        = LoggerFactory.Create(builder => { builder.ClearProviders(); builder.AddProvider() });


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int p3aId = 1;
            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.HasData(new Classroom { ClassroomId = p3aId, Name = "P3A" });
            });
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasData(new Student { StudentId = 1, FirstName = "Alfons", LastName = "Smutný", ClassroomId = p3aId });
            });   
        }
    }
}
/*
Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = veverka; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate=False; Application Intent = ReadWrite; Multi Subnet Failover=False

 PM> Add-Migration Init
 PM> Update-Database
 */