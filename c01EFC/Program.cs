// See https://aka.ms/new-console-template for more information
using c01EFC.Data;

ApplicationDbContext context = new ApplicationDbContext();
foreach(var s in context.Students.ToList())
{
    Console.WriteLine(s.FullName);
}
