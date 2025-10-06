// See https://aka.ms/new-console-template for more information
using c03dapper.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DapStudents;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

using (var connection = new SqlConnection(cs))
{
    connection.Open();
    Console.WriteLine("Database connection established.");

    var ver = connection.ServerVersion;
    Console.WriteLine($"Server version: {ver}");
    var ver2 = connection.ExecuteScalar<string>("SELECT @@VERSION");
    Console.WriteLine($"Server version: {ver2}");

    var sqlCreate = @"
         CREATE TABLE Students (
             StudentId INT PRIMARY KEY IDENTITY,
             FirstName NVARCHAR(50) NOT NULL,
             LastName NVARCHAR(50) NOT NULL,
             Grade INT NOT NULL
         )";
    try
    {
        var res = connection.Execute(sqlCreate);
        Console.WriteLine(res);
        if (res > 0) Console.WriteLine("Table created.");
        else Console.WriteLine("Table creation failed or table already exists.");
    }
    catch (SqlException ex) when (ex.Number == 2714) // Error number for "There is already an object named 'Students' in the database."
    {
        Console.WriteLine("Table already exists.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error creating table: {ex.Message}");
    }

    // execute = insert, update, delete
    var sqlInsert = "INSERT INTO Students (FirstName, LastName, Grade) VALUES (@FirstName, @LastName, @Grade)";
    var student = new { FirstName = "John", LastName = "Doe", Grade = 90 };
    var rowsInserted = connection.Execute(sqlInsert, student);
    Console.WriteLine($"{rowsInserted} row(s) inserted.");

    // query = select
    var sqlSelect = "SELECT StudentId, FirstName, LastName, Grade FROM Students";
    var students = connection.Query<Student>(sqlSelect);
    if (students.Any())
    {
        foreach (var s in students)
        {
            Console.WriteLine($"{s.StudentId}: {s.FirstName} {s.LastName}, Grade: {s.Grade}");
        }
    }
    else
    {
        Console.WriteLine("No students found.");
    }

    var studentsX = connection.QueryFirstOrDefault<Student>("SELECT * FROM Students WHERE Grade > @MinGrade", new { MinGrade = 85 });
    if (studentsX != null)
    {
        Console.WriteLine($"First student with grade > 85: {studentsX.FirstName} {studentsX.LastName}, Grade: {studentsX.Grade}");
    }
    else
    {
        Console.WriteLine("No student found with grade > 85.");
    }
}
