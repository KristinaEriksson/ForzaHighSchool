using ForzaHighSchool.Data;
using ForzaHighSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ForzaHighSchool
{
    public class Entity_Framework
    {
        public static void AllStudents()
        {
            Console.Clear();
            Console.WriteLine("All students");
            Console.WriteLine(new string('^', (33)));

            // Connection between VS and the database
            using var context = new HighSchoolDbContext();

            // Get the data from the database and it order by firstname in descending order
            var myStudents = context.Students.OrderByDescending(s => s.FirstName);

            // write out the data
            foreach (var item in myStudents)
            {
                Console.WriteLine("Name: " + item.FirstName + " " + item.LastName);
                Console.WriteLine("Social security number: " + item.SocialSecurityNumber);
                Console.WriteLine("Class: " + item.Class);
                Console.WriteLine(new string('-', (33)));
            }
            Console.WriteLine(new string('^', (33)));
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.EntityFrameworkMenu();
        }
        public static void CourseList()
        {
            // Connection
            using var context = new HighSchoolDbContext();
            // Get the data from the database 
            var courseList = context.Students.Select(c => new { c.Class }).Distinct();
            // Write out the data from the database that was received
            foreach (var item in courseList)
            {
                Console.WriteLine(item.Class);
                Console.WriteLine(new string('-', (33)));
            }


            Console.WriteLine(new string('^', (33)));
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.EntityFrameworkMenu();
        }
        public static void Departments()
        {
            // Connenction 
            using var context = new HighSchoolDbContext();
            // Get the data from the database
            var departments = context.Employees.GroupBy(x => x.Title).Select(x => new { dept = x.Key, EmployeesCount = x.Count() });
            // Write out the data from the database that was received
            foreach (var item in departments)
            {
                Console.WriteLine(item.dept);
                Console.WriteLine(item.EmployeesCount);
                Console.WriteLine(new string('-', (33)));
            }
            Console.WriteLine(new string('^', (33)));
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.EntityFrameworkMenu();
        }
    }
}
