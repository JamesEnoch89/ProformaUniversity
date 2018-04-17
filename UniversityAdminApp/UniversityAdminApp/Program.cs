using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAdminApp
{
    class Program
    {

        static void Main(string[] args)
        {
            // location of the databse
            const string CONNECTION_STRING = @"Server=localhost\SQLEXPRESS;Database=ProformaUniversity;Trusted_Connection=True;";
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                // open connection, run program while connection is open. exit if not.
                conn.Open();

                var openMainMenu = true;
                while (openMainMenu == true)
                // admin menu
                {
                    // prompt user for selection
                    Console.WriteLine("Proforma University Admin Menu");
                    Console.WriteLine("Select from the following:");
                    Console.WriteLine("(1) Add a course");
                    Console.WriteLine("(2) Add a Professor");
                    Console.WriteLine("(3) View all courses");
                    Console.WriteLine("(4) View all Professors");
                    Console.WriteLine("(5) View the student enrollments");
                    Console.WriteLine("(6) View all course data");
                    Console.WriteLine("(7) To exit");
                    var selectionInput = Console.ReadLine();
                    // create course and prompt user 
                    if (selectionInput == "1")
                    {

                        var newCourse = Factory.CreateCourse();
                        Factory.InsertCourse(conn, newCourse);
                        Console.WriteLine($"You've added: {newCourse.NewCourseName}");

                    }
                    // create professor and prompt user
                    else if (selectionInput == "2")
                    {
                        var newProfessor = Factory.CreateProfessor();
                        Factory.InsertProfessor(conn, newProfessor);
                        Console.WriteLine($"You've added: {newProfessor.NewProfessorName}");

                    }
                    // prompt user with view options or to exit
                    else if (selectionInput == "3")
                    {
                        Factory.GetAllCourses(conn);
                    }
                    else if (selectionInput == "4")
                    {
                        Factory.GetAllProfessors(conn);
                    }
                    else if (selectionInput == "5")
                    {
                        Factory.ViewEnrolled(conn);
                    }
                    else if (selectionInput == "6")
                    {
                        Factory.GetAllCourseInfo(conn);
                    }
                    else if (selectionInput == "7")
                    {
                        Console.WriteLine("You are now logged out");
                        openMainMenu = false;
                    }
                }
            }
        }
    }
}