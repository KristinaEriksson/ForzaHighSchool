using ForzaHighSchool.Data;
using ForzaHighSchool.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForzaHighSchool
{
    public class Lab3
    {
        public static void EmployeeMenu()
        {
            Console.Clear();
            Console.WriteLine("Employee Menu");
            Console.WriteLine(new string('^', (36)));
            Console.WriteLine("1. All Employees");
            Console.WriteLine("2. Teacher");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine(new string('^', (36)));
            Console.Write("Enter a number to select an option: ");

            int keyInput = Convert.ToInt32(Console.ReadLine());

            switch (keyInput)
            {
                case 1:
                    Employees();
                    break;
                case 2:
                    Teachers();
                    break;
                case 0:
                    Menu.Lab3Menu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine(new string('^', (36)));
                    Console.WriteLine("Invalid choice!!");
                    Console.WriteLine("Press Enter to try again.");
                    Console.WriteLine(new string('^', (36)));
                    Console.ReadKey();
                    break;
            }
        }
        public static void Employees()
        {
            // All Employees SQL
            Console.Clear();
            Console.WriteLine("All Employees");
            Console.WriteLine(new string('^', (33)));

            // Connection between VS and SSMS database
            SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-8VGM57M; Initial Catalog = HighSchool3.0; Integrated Security = true");

            // Fetch data from HighSchool3.0
            SqlDataAdapter sqlData = new SqlDataAdapter("select * from Employee", sqlCon);

            // Empty data table
            DataTable dtTbl = new DataTable();

            // Add data to the empty data table
            sqlData.Fill(dtTbl);

            // Write out the data from database
            foreach (DataRow dr in dtTbl.Rows)
            {
                Console.WriteLine("Employment number: " + dr["EmploymentNumber"]);
                Console.WriteLine(dr["FirstName"] + " " + dr["LastName"]);
                Console.WriteLine("Social Security number: " + dr["SocialSecurityNumber"]);
                Console.WriteLine("Title: " + dr["Title"]);
                Console.WriteLine("Salary: " + dr["Salary"]);
                Console.WriteLine("Emplyment date: " + dr["EmploymentDate"]);
                Console.WriteLine(new string('-', (33)));
            }
            Console.WriteLine("Press Enter to go to the menu.");
            Console.ReadLine();
            EmployeeMenu();
        }
        public static void Teachers()
        {
            // Employees 'Teachers' SQL
            Console.Clear();
            Console.WriteLine("Teachers");
            Console.WriteLine(new string('^', (33)));

            // SQL string, used to get some data from the database
            string teachers = "select * from Employee where Title = 'Teacher'";

            // Connection between VS and SMSS database
            SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-8VGM57M; Initial Catalog = HighSchool3.0; Integrated Security = true");

            // Fetch data from HighSchool3.0
            SqlDataAdapter dataSql = new SqlDataAdapter(teachers, sqlCon);

            // Empty data table
            DataTable dtTbl = new DataTable();

            // Add data to the empty data table
            dataSql.Fill(dtTbl);

            // Write out the data from the database
            foreach (DataRow dr in dtTbl.Rows)
            {
                Console.WriteLine("Employment number: " + dr["EmploymentNumber"]);
                Console.WriteLine(dr["FirstName"] + " " + dr["LastName"]);
                Console.WriteLine("Social Security Number: " + dr["SocialSecurityNumber"]);
                Console.WriteLine("Title: " + dr["Title"]);
                Console.WriteLine("Salary: " + dr["Salary"]);
                Console.WriteLine("Employment date: " + dr["EmploymentDate"]);
                Console.WriteLine(new string('-', (33)));
            }
            Console.WriteLine("Press Enter to go to the menu.");
            Console.ReadLine();
            EmployeeMenu();
        }
        
}
}
