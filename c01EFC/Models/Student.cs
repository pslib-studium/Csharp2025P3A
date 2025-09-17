using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c01EFC.Models
{
    internal class Student
    {
        public int StudentId { get; set; }
        //public int Id { get; set; }
        /*
        [Key] public int Klic { get; set; }
        */
        [Required, MinLength(3)]
        [MaxLength(30)]
        public required string FirstName { get; set; }
        public required string LastName { get; set; } = String.Empty;
        public string? MiddleName { get; set; }
        public string FullName { get {
            return FirstName + " " + LastName;
            } }
        // Navigation property
        [ForeignKey(nameof (Classroom))]
        public int ClassroomId { get; set; }
        public Classroom? Classroom { get; set; } // N:1 many-to-one
    }
}
