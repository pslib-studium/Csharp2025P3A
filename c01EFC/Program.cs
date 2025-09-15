// See https://aka.ms/new-console-template for more information
using c01EFC.Data;
using c01EFC.Models;

ApplicationDbContext context = new ApplicationDbContext();
foreach(var s in context.Students.ToList())
{
    Console.WriteLine(s.FullName);
}

try
{
    context.Students.Add(
        new Student
        {
            FirstName = "Anna", 
            LastName = "Nováková" 
        }
        );
    context.SaveChanges();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
foreach (var s in context.Students.ToList())
{
    Console.WriteLine(s.FullName);
}