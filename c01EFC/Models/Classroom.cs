using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c01EFC.Models
{
    internal class Classroom
    {
        public int ClassroomId { get; set; }
        public required string Name { get; set; }
        public ICollection<Student>? Students { get; set; } // 1:N one-to-many
    }
}
