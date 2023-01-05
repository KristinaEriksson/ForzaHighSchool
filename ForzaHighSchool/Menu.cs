using ForzaHighSchool.Data;
using ForzaHighSchool.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForzaHighSchool
{
    public class Menu
    {
        public void HighShcoolMenu()
        {
            Console.Clear();


            Console.WriteLine("Forza HighSchool");
            Console.WriteLine(new string('^', (36)));
            Console.WriteLine("[0] Exit");
            Console.WriteLine("[1] SQL");
            Console.WriteLine("[2] Entity Framework");
            Console.WriteLine("[3] Extra");
            Console.WriteLine("[4] Lab3");


            int menuChoice = Convert.ToInt32(Console.ReadLine());
            switch (menuChoice)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    SqlMenu();
                    break;
                case 2:
                    EntityFrameworkMenu();
                    break;
                case 3:
                    ExtraMenu();
                    break;
                case 4:
                    Lab3Menu();
                    break;
                default:
                    Console.WriteLine("Invalid choice, please enter a number between 0-4");
                    Console.WriteLine("Hit enter key to try again");
                    Console.ReadLine();
                    HighShcoolMenu();
                    break;
            }
        }
        public void SqlMenu()
        {
            Console.Clear();
            

            Console.WriteLine("SQL - Menu");
            Console.WriteLine(new string('^', (36)));
            Console.WriteLine("[0] Return to Main Menu");
            Console.WriteLine("[1] Employee List");
            Console.WriteLine("[2] New Employee");
            Console.WriteLine("[3] Student List");
            Console.WriteLine("[4] Grades");
            Console.WriteLine("[5] New Student");
            Console.WriteLine("[6] Salary every month");
            Console.WriteLine("[7] Average Salary");
            Console.WriteLine("[8] Stored Procedure");
            Console.WriteLine("[9] Transaction");

            int sqlChoice = Convert.ToInt32(Console.ReadLine());
            switch (sqlChoice)
            {
                case 0:
                    HighShcoolMenu();
                    break;
                case 1:
                    Console.Clear();
                    Sql.AllEmployees();
                    break;
                case 2:
                    Console.Clear();
                    Sql.NewEmployee();
                    break;
                case 3:
                    Console.Clear();
                    Sql.AllStudents();
                    break;
                case 4:
                    Console.Clear();
                    Sql.Grades();
                    break;
                case 5:
                    Console.Clear();
                    Sql.NewStudent();
                    break;
                case 6:
                    Console.Clear();
                    Sql.MonthlyPayout();
                    break;
                case 7:
                    Console.Clear();
                    Sql.AverageSalary();
                    break;
                case 8:
                    Console.Clear();
                    Sql.Procedure();
                    break;
                case 9:
                    Console.Clear();
                    Sql.Transaction();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice!!\n"
                        + "Enter to try again!");
                    Console.ReadLine();
                    break;

            }
        }



        public void EntityFrameworkMenu()
        {
            Console.Clear();
            Console.WriteLine("Entity Framework Menu");
            Console.WriteLine(new string('^', (36)));
            Console.WriteLine("[0] Return to Main Menu");
            Console.WriteLine("[1] All Students");
            Console.WriteLine("[2] Current Course List");
            Console.WriteLine("[3] Teachers in each department");

            int efChoice = Convert.ToInt32(Console.ReadLine());
            switch (efChoice)
            {
                case 0:
                    HighShcoolMenu();
                    break;
                case 1:
                    Console.Clear();
                    Entity_Framework.AllStudents();
                    break;
                case 2:
                    Console.Clear();
                    Entity_Framework.CourseList();
                    break;
                case 3:
                    Console.Clear();
                    Entity_Framework.Departments();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice!!\n"
                        + "Enter to try again!");
                    Console.ReadLine();
                    break;
            }
        }
        public void ExtraMenu()
        {
            Console.Clear();
            Console.WriteLine("Extra Challenge Menu");
            Console.WriteLine(new string('^', (36)));
            Console.WriteLine("[1] Info One Student");
            Console.WriteLine("[2] View");
            Console.WriteLine("[3] Update info");

            int extraChoice = Convert.ToInt32(Console.ReadLine());

            switch (extraChoice)
            {
                case 1:
                    Console.Clear();
                    Extra.InfoStudent();
                    break;
                case 2:
                    Console.Clear();
                    Extra.View();
                    break;
                case 3:
                    Console.Clear();
                    Extra.UpdateInfo();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice!!\n"
                        + "Enter to try again!");
                    Console.ReadLine();
                    break;
            }
        }
        public static void Lab3Menu()
        {
            Console.Clear();
            Console.WriteLine("Forza HighSchool");
            Console.WriteLine(new string('^', (36)));
            Console.WriteLine("1. Employees");
            Console.WriteLine("2. Students");
            Console.WriteLine("3. Add new student");
            Console.WriteLine("4. Add new employee");
            Console.WriteLine("5. Return to Main Menu");
            Console.WriteLine("0. Exit");
            Console.WriteLine(new string('^', (36)));
            Console.Write("Enter a number to select an option: ");
            int input = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                Menu menu = new Menu();

                switch (input)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                         Lab3.EmployeeMenu();
                        break;
                    case 2:
                        Students();
                        break;
                    case 3:
                        AddStudent();
                        break;
                    case 4:
                        AddEmployee();
                        break;
                    case 5:
                        menu.HighShcoolMenu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine(new string('^', (36)));
                        Console.WriteLine("Invalid option!!\nPlease try again by hit the enter key.");
                        Console.WriteLine(new string('^', (36)));
                        Console.ReadLine();
                        menu.HighShcoolMenu();
                        break;
                }
            }
        }
        public static void Students()
        {
            // All students EF

            Console.Clear();
            Console.WriteLine("All students: ");
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
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();

            // All the classes EF
            Console.WriteLine("All the Classes");
            Console.WriteLine(new string('^', (33)));

            // Get the data from the database, all classes, using distinct to remove duplicates
            var myStudents2 = context.Students.Select(c => new { c.Class }).Distinct();

            // Write out the data
            foreach (var item in myStudents2)
            {
                Console.WriteLine(item.Class);
                Console.WriteLine(new string('*', (33)));
            }
            Console.WriteLine("Press Enter key to continue");
            Console.ReadLine();
            Console.Clear();

            // One class EF
            Console.WriteLine("All the students in class Teknik");
            Console.WriteLine(new string('^', (33)));

            // Get all the students in class Teknik
            var myStudents3 = from student in context.Students
                              where student.Class == "Teknik"
                              select student;
            // Write out the data
            foreach (var item in myStudents3)
            {
                Console.WriteLine("Name: " + item.FirstName + " " + item.LastName);
                Console.WriteLine("Class: " + item.Class);
                Console.WriteLine(new string('-', (33)));
            }

            Console.WriteLine("Press Enter key to continue");
            Console.ReadLine();
            Console.Clear();

            // Recent grades SQL
            Console.WriteLine("Recent grades: ");
            Console.WriteLine(new string('^', (33)));

            // Connection between VS and SSMS
            SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-8VGM57M; Initial Catalog = HighSchool3.0; Integrated Security = true");

            // Get the data from the database HighSchool3.0, Subject which are set later then 2022-11-01
            SqlDataAdapter dtGrade = new SqlDataAdapter("select StudentName, Subject, Grade from Grade where SetDate > '2022-11-01'", sqlCon);
            // Empty data table
            DataTable dataGrade = new DataTable();
            // Add data to the empty data table
            dtGrade.Fill(dataGrade);

            // Write out data
            foreach (DataRow dr in dataGrade.Rows)
            {
                Console.WriteLine(dr["StudentName"]);
                Console.WriteLine(dr["Subject"] + " " + "Grade: " + dr["Grade"]);
                Console.WriteLine(new string('-', (33)));
            }

            Console.WriteLine("Press Enter key to continue");
            Console.ReadLine();
            Console.Clear();

            // Average grade SQL
            Console.WriteLine("Average, Max and Min grades");
            Console.WriteLine(new string('^', (33)));

            // Get data from database, Average, Max and Min grade in each subject
            SqlDataAdapter dataGrades = new SqlDataAdapter("select subject, AVG(Grade)as AverageGrade, Max(Grade)as HighestGrade, Min(Grade)as LowestGrade from Grade group by subject", sqlCon);

            // Empty data table
            DataTable recentGrades = new DataTable();
            // Add data to the empty data table
            dataGrades.Fill(recentGrades);

            // Write out the data
            foreach (DataRow dr in recentGrades.Rows)
            {
                Console.WriteLine(dr["Subject"]);
                Console.WriteLine("Averagegrade: " + dr["AverageGrade"]);
                Console.WriteLine("Highestgrade: " + dr["HighestGrade"]);
                Console.WriteLine("Lowestgrade: " + dr["LowestGrade"]);
                Console.WriteLine(new string('-', (33)));
            }
            Console.WriteLine("Press Enter key to go to the menu.");
            Console.ReadLine();
            Lab3Menu();

        }
        public static void AddStudent()
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
            string ssn = Console.ReadLine();
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
                cmd.Parameters.Add(@"SocialSecurityNumber", SqlDbType.VarChar, 12).Value = ssn;
                cmd.Parameters.Add(@"Class", SqlDbType.NVarChar, 50).Value = stuClass;

                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            Console.WriteLine("A new student has been added to the database.");
            Console.WriteLine("Press Enter key to go to the menu.");
            Console.ReadLine();
            
            Lab3Menu();

        }
        public static void AddEmployee()
        {
            while (true)
            {
                Console.Clear();

                // Connection between VS and database
                using var context = new HighSchoolDbContext();
                // Create a object
                Employee E1 = new Employee();

                // Create a random number to employee
                Random empNr = new Random();
                int randNumber = empNr.Next(00000, 99999);

                Console.WriteLine("Add a new employee");
                Console.WriteLine(new string('^', (33)));

                // Users input, firstname,lastname,social security number,title and salary
                // Employment Date and Employment Number is filled in automatically  
                Console.Write("Enter firstName: ");
                string fName = Console.ReadLine();
                Console.Write("Enter lastName: ");
                string lName = Console.ReadLine();
                Console.Write("Enter Social Security Number(YYYYMMDDXXXX): ");
                string ssn = Console.ReadLine();
                Console.Write("Enter title: ");
                string title = Console.ReadLine();
                Console.Write("Enter salary: ");
                decimal salary = Convert.ToDecimal(Console.ReadLine());
                DateTime currentDateTime = DateTime.Now;

                // Adding users input to the object E1
                E1.EmploymentNumber = randNumber;
                E1.FirstName = fName;
                E1.LastName = lName;
                E1.SocialSecurityNumber = ssn;
                E1.Title = title;
                E1.Salary = salary;
                E1.EmploymentDate = currentDateTime;

                // Adding the object E1 to the database
                context.Employees.Add(E1);
                context.SaveChanges();

                Console.WriteLine("A new employee has been added to the database.");
                Console.WriteLine("Press Enter key to go to the menu.");
                Console.ReadLine();
                
                Lab3Menu();
            }
        }
    }
}
    

