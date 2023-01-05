using ForzaHighSchool.Data;
using ForzaHighSchool.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ForzaHighSchool
{
    public class Extra
    {
        public static void InfoStudent()
        {
            Console.Clear();
            Console.WriteLine("Info about a one student.");
            Console.WriteLine(new string('^', (33)));
            // Connection
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-8VGM57M; Initial Catalog = HighSchool3.0; Integrated Security=true");
            // Get data from the database
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT CONCAT (Student.FirstName,' ', Student.LastName) AS Student, Student.Class, Grade.Subject, Grade.Grade, Employee.Title, CONCAT(Employee.FirstName,' ', Employee.LastName) AS Teacher FROM Student " +
                                                        "join Grade on StudentId = FK_StudentId " +
                                                        "join Employee on EmploymentNumber = FK_EmploymentNumber " +
                                                        "WHERE StudentId = 1;", sqlConnection);

            // Empty datatable                                         
            DataTable dataTable = new DataTable();
            // Add the data to the datatable
            sqlData.Fill(dataTable);

            // Write out the data from the datatable
            foreach (DataRow dr in dataTable.Rows)
            {
                Console.WriteLine(dr["Student"]);
                Console.WriteLine("Class: " + dr["Class"]);
                Console.WriteLine(dr["Subject"]);
                Console.WriteLine("Grade: " + dr["Grade"]);
                Console.WriteLine(dr["Title"] + ": " + dr["Teacher"]);
                Console.WriteLine(new string('^', (33)));
            }
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.ExtraMenu();
        }
        public static void View()
        {
            Console.Clear();
            Console.WriteLine("Create a view.");

            // Connection string
            string connectionString = (@"Data Source = DESKTOP-8VGM57M; Initial Catalog = HighSchool3.0; Integrated Security = true");
            // Create a view with default values
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("CREATE VIEW Grades AS SELECT StudentName, Subject, Grade FROM Grade WHERE FK_StudentId = 1", connection);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("A view has been created in the database.");
            Console.WriteLine(new string('^', (33)));
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.ExtraMenu();
        }
        public static void UpdateInfo()
        {
            Console.Clear();
            Console.WriteLine("Update data. (Default values)");
            // Connection 
            using (var context = new HighSchoolDbContext())
            {
                // Update data with transaction with default values and exection rollback if something went wrong
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var student = context.Students.FirstOrDefault(s => s.StudentId == 6);
                        student.FirstName = "Svea";
                        student.LastName = "Persson";
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
            Console.WriteLine("Changes has been added to the database.");
            Console.WriteLine(new string('^', (33)));
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.ExtraMenu();
        }
    }
}
