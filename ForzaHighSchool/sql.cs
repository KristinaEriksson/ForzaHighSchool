using ForzaHighSchool;
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
    public class Sql
    {
        public static void AllEmployees()
        {
            Console.Clear();
            Console.WriteLine("All Employees");
            Console.WriteLine(new string('^', (33)));
            // Connection
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-8VGM57M; Initial Catalog = HighSchool3.0; Integrated Security=true");
            // Get data from the database
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT Title, FirstName, LastName, DATEDIFF(YEAR, EmploymentDate, GETDATE()) AS 'Number of years employed' FROM Employee", sqlConnection);
            // Empty datatable
            DataTable dataTable = new DataTable();
            // Add the data to the empty datatable
            sqlData.Fill(dataTable);

            // Write out the data from datatable
            foreach (DataRow dr in dataTable.Rows)
            {
                Console.WriteLine("Title: " + dr["Title"]);
                Console.WriteLine(dr["FirstName"] + " " + dr["LastName"]);
                Console.WriteLine("Number of years employed: " + dr["Number of years employed"]);
                Console.WriteLine(new string('^', (33)));
            }
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.SqlMenu();
        }
        public static void NewEmployee()
        {
            Console.Clear();
            Console.WriteLine("Add a new employee");
            Console.WriteLine(new string('^', (33)));
            // Connection
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-8VGM57M; Initial Catalog = HighSchool3.0; Integrated Security=true");
            // Create a random number
            Random empNr = new Random();
            int randNumber = empNr.Next(00000, 99999);

            // Get some input from the user, firstname, lastname, social security number, title and salary
            Console.Write("Enter firstname: ");
            string fName = Console.ReadLine();
            Console.Write("Enter lastname: ");
            string lName = Console.ReadLine();
            Console.Write("Enter social security number(YYYYMMDDXXXX): ");
            string ssNumber = Console.ReadLine();
            Console.Write("Enter work title: ");
            string title = Console.ReadLine();
            Console.Write("Enter monthly salary in swedish krona: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            var currentDate = DateOnly.FromDateTime(DateTime.Now);

            // SQL string, to insert the values to the database
            string addNew = "INSERT INTO Employee (EmploymentNumber, FirstName, LastName, SocialSecurityNumber, Title, Salary, EmploymentDate)" +
                "VALUES (@EmploymentNumber, @FirstName, @LastName, @SocialSecurityNumber, @Title, @Salary, @EmploymentDate)";

            // Insert values into the database with users input
            using (SqlCommand cmd = new SqlCommand(addNew, sqlConnection))
            {
                cmd.Parameters.Add(@"EmploymentNumber", SqlDbType.NVarChar, 50).Value = randNumber;
                cmd.Parameters.Add(@"FirstName", SqlDbType.NVarChar, 50).Value = fName;
                cmd.Parameters.Add(@"LastName", SqlDbType.NVarChar, 50).Value = lName;
                cmd.Parameters.Add(@"SocialSecurityNumber", SqlDbType.NVarChar, 50).Value = ssNumber;
                cmd.Parameters.Add(@"Salary", SqlDbType.NVarChar, 50).Value = salary;
                cmd.Parameters.Add(@"EmploymentDate", SqlDbType.NVarChar, 50).Value = currentDate;

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            Console.WriteLine("A new employee has been added to the database.");
            Console.WriteLine(new string('^', (33)));
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.SqlMenu();
        }
        public static void AllStudents()
        {
            Console.Clear();
            Console.WriteLine("All Students");
            Console.WriteLine(new string('^', (33)));
            // Connection to the database and fetch data from database HighSchool 3.0
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-8VGM57M; Initial Catalog = HighSchool3.0; Integrated Security=true");
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT FirstName, LastName, Class FROM Student", sqlConnection);

            // Empty datatable
            DataTable dataTable = new DataTable();
            // Add data to the empty data table
            sqlData.Fill(dataTable);

            // Write out the data from database
            foreach (DataRow dr in dataTable.Rows)
            {
                Console.WriteLine(dr["FirstName"] + " " + dr["LastName"]);
                Console.WriteLine("Class: " + dr["Class"]);
                Console.WriteLine(new string('^', (33)));
            }
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.SqlMenu();
        }
        public static void Grades()
        {
            Console.Clear();
            Console.WriteLine("Student Grade");
            Console.WriteLine(new string('^', (33)));
            // Connection to database HighSchool 3.0
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-8VGM57M; Initial Catalog = HighSchool3.0; Integrated Security=true");
            // Fetch data from HighSchool3.0
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT Student.StudentId, Student.FirstName, Student.LastName, Subject, Grade, CONCAT(Employee.FirstName,' ', Employee.LastName) AS Teacher, SetDate FROM Student " +
                                                            "JOIN Grade ON StudentId = FK_StudentId " +
                                                            "JOIN Employee ON EmploymentNumber = FK_EmploymentNumber " +
                                                            "WHERE StudentId = 1", sqlConnection);
            // Empty datatabele
            DataTable dataTable = new DataTable();
            // Add data to the empty data table
            sqlData.Fill(dataTable);

            // Write out the data from database
            foreach (DataRow dr in dataTable.Rows)
            {
                Console.WriteLine(dr["FirstName"] + " " + dr["LastName"]);
                Console.WriteLine("Class: " + dr["Subject"] + " " + dr["Grade"]);
                Console.WriteLine("Set by: " + dr["Teacher"]);
                Console.WriteLine("Set date: " + dr["SetDate"]);
                Console.WriteLine(new string('^', (33)));
            }
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.SqlMenu();
        }
        public static void NewStudent()
        {
            //Add new student SQL
            Console.Clear();
            Console.WriteLine("Add a new student");
            Console.WriteLine(new string('^', (33)));

            // Get input from the user, firstname, lastname, social security number and class
            Console.Write("Enter firstName: ");
            string fName = Console.ReadLine();
            Console.Write("Enter lastName: ");
            string lName = Console.ReadLine();
            Console.Write("Enter social security number(YYYYMMDDXXXX): ");
            string ssNumber = Console.ReadLine();
            Console.Write("Enter class: ");
            string stuClass = Console.ReadLine();

            // Connection between VS and database
            SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-8VGM57M; Initial Catalog = HighSchool3.0; Integrated Security = true");
            // SQL string, to insert the values to the database
            string addNew = "insert into Student (FirstName, LastName, SocialSecurityNumber, Class) " +
                "values (@FirstName, @LastName, @SocialSecurityNumber, @Class) ";

            // Insert values into the database with users input
            using (SqlCommand cmd = new SqlCommand(addNew, sqlCon))
            {
                cmd.Parameters.Add(@"FirstName", SqlDbType.NVarChar, 50).Value = fName;
                cmd.Parameters.Add(@"LastName", SqlDbType.NVarChar, 50).Value = lName;
                cmd.Parameters.Add(@"SocialSecurityNumber", SqlDbType.VarChar, 12).Value = ssNumber;
                cmd.Parameters.Add(@"Class", SqlDbType.NVarChar, 50).Value = stuClass;

                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            Console.WriteLine("A new student has been added to the database.");
            Console.WriteLine(new string('^', (33)));
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.SqlMenu();
        }

        public static void MonthlyPayout()
        {
            
            Console.Clear();
            Console.WriteLine("Monthly payouts");
            Console.WriteLine(new string('^', (33)));
            // Connections string
            SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-8VGM57M; Initial Catalog = HighSchool3.0; Integrated Security = true");
            // Fetch data from HighSchool3.0
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT Title, SUM(Salary) AS 'Total Monthly Payouts' FROM Employee " +
                                                        "GROUP BY Title", sqlCon);
            // Empty data table
            DataTable dataTable = new DataTable();
            // Add data to the empty data table
            sqlData.Fill(dataTable);

            // Write out the data from database
            foreach (DataRow dr in dataTable.Rows)
            {
                Console.WriteLine(dr["Title"] + " " + dr["Total Monthly Payouts"] + " " + "KR every month");
                Console.WriteLine(new string('-', (33)));
            }
            Console.WriteLine(new string('^', (33)));
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.SqlMenu();
        }
        public static void AverageSalary()
        {
            Console.Clear();
            Console.WriteLine("Average Salary");
            Console.WriteLine(new string('^', (33)));
            // Connections string
            SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-8VGM57M; Initial Catalog = HighSchool3.0; Integrated Security = true");

            // Fetch data from HighSchool3.0
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT Title, AVG(Salary) AS 'Average Salary' FROM Employee " +
                                                        "GROUP BY Title", sqlCon);
            // Empty data table
            DataTable dataTable = new DataTable();
            // Add data to the empty data table
            sqlData.Fill(dataTable);

            // Write out the data from database
            foreach (DataRow dr in dataTable.Rows)
            {
                Console.WriteLine(dr["Title"] + " " + dr["Average Salary"] + " " + "KR");
                Console.WriteLine(new string('-', (33)));
            }
            Console.WriteLine(new string('^', (33)));
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.SqlMenu();
        }
        public static void Procedure()
        {
            Console.Clear();
            Console.WriteLine("Call a Stored Procedure");
            Console.WriteLine(new string('^', (33)));

            // Call a stored procedure from the database
            // Connection string to database
            string connectionString = (@"Data Source = DESKTOP-8VGM57M; Initial Catalog = HighSchool3.0; Integrated Security = true");


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Fetch information from a stored procedure with default parameter(StudentId = 1) in database
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_Student_Id";

                    SqlParameter parameter = new SqlParameter("@StudentId", SqlDbType.Int);
                    parameter.Value = 1;
                    cmd.Parameters.Add(parameter);

                    // Write out the information from stored procedure
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Student Id: {reader[0]}\nName: {reader[1]} {reader[2]}\nSocial security number: {reader[3]}\nClass: {reader[4]}");
                        }
                    }
                }
            }
            Console.WriteLine(new string('^', (33)));
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.SqlMenu();
        }
        public static void Transaction()
        {
            Console.Clear();
            Console.WriteLine("Add a new grade on student");
            Console.WriteLine(new string('^', (33)));

            // Get input from the user
            Console.Write("Enter which student ID applies: ");
            var stuId = Console.ReadLine();
            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine();
            Console.Clear();

            Console.Write("Enter subject: ");
            string subject = Console.ReadLine();
            Console.Write("Enter grade that the student got on the subject(a number between 1-5): ");
            int grade = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.Write("Enter Employment number on the teacher which is grading the student: ");
            int empNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter teachers name which is grading the student: ");
            string teacherName = Console.ReadLine();
            DateTime currentDate = DateTime.Now;

            // Connection string to the database
            string connectionString = (@"Data Source = DESKTOP-8VGM57M; Initial Catalog = HighSchool3.0; Integrated Security = true");
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                // Start a local transaction
                SqlTransaction transaction = sqlCon.BeginTransaction();
                SqlCommand cmd = sqlCon.CreateCommand();
                cmd.Transaction = transaction;
                
                // Insert the values to the database
                try
                {
                    cmd.CommandText = "INSERT INTO Grade(FK_StudentId, StudentName, Subject, Grade, FK_EmploymentNumber, EmployeeName, SetDate)" +
                        "VALUES (@stuId, @studentName, @subject, @grade, @empNumber, @teacherName,@currentDate)";
                    cmd.Parameters.AddWithValue("@stuId", stuId);
                    cmd.Parameters.AddWithValue("@studentName", studentName);
                    cmd.Parameters.AddWithValue("@subject", subject);
                    cmd.Parameters.AddWithValue("@grade", grade);
                    cmd.Parameters.AddWithValue("@empNumber", empNumber);
                    cmd.Parameters.AddWithValue("@teacherName", teacherName);
                    cmd.Parameters.AddWithValue("@currentDate", currentDate);
                    
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    
                    Console.WriteLine("Grade has been added to the database.");
                }
                // catch if something is't right
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exeption Type: {0}", ex.GetType());
                    Console.WriteLine("Message: {0}", ex.Message);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("Message: {0}", ex2.Message); 
                    }
                }
            }
            Console.WriteLine(new string('^', (33)));
            Console.WriteLine("Enter to go back to menu");
            Console.ReadLine();
            Menu menu = new Menu();
            menu.SqlMenu();
        }
    }
}
