// See https://aka.ms/new-console-template for more information
using c01EFC.Data;
using c01EFC.Models;
using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new ApplicationDbContext();
foreach(var s in context.Students.Include(s => s.Classroom).ToList())
{
    Console.WriteLine(s.FullName);
    Console.WriteLine(s.Classroom?.Name);
}
/*
try
{
    context.Students.Add(
        new Student
        {
            FirstName = "Anna", 
            LastName = "Nováková",
            ClassroomId = 1
        }
        );
    context.SaveChanges();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
*/
foreach (var cls in context.Classrooms.Include(c => c.Students).ToList())
{
    Console.WriteLine(cls.Name);
    foreach (var st in cls.Students)
    {
        Console.WriteLine("  " + st.FullName);
    }
}
Classroom cl_PA = context.Classrooms
    .FirstOrDefault(c => c.Name == "P3A");
if (cl_PA != null)
{
    context.Entry(cl_PA).Collection(c => c.Students).Load();
}