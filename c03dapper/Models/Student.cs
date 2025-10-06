using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c03dapper.Models
{
    internal class Student
    {
        public int StudentId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Grade { get; set; }
    }
}
