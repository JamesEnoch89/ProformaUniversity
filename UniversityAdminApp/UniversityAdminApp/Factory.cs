using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAdminApp
{
    class Factory
    {
        // read for course info
        public static Courses CreateCourse()
        {
            Console.WriteLine("What is the course number?");
            var courseNumberFromInput = Console.ReadLine();
            Console.WriteLine("What level is the course?");
            var courseLevelFromInput = Console.ReadLine();
            Console.WriteLine("What is the course name?");
            var courseNameFromInput = Console.ReadLine();
            Console.WriteLine("What room is the course held in?");
            var courseRoomFromInput = Console.ReadLine();
            Console.WriteLine("What time does this course start?");
            var courseTimeFromInput = Console.ReadLine();

            // store input values for courses

            var newCourse = new Courses
            {
                NewCourseNumber = courseNumberFromInput,
                NewCourseLevel = courseLevelFromInput,
                NewCourseName = courseNameFromInput,
                NewCourseRoom = courseRoomFromInput,
                NewCourseTime = courseTimeFromInput
            };
            return newCourse;
        }

        // read for professor info
        public static Professors CreateProfessor()
        {
            Console.WriteLine("What is the Professor's name?");
            var professorNameFromInput = Console.ReadLine();
            Console.WriteLine("What is the Professor's title?");
            var professorTitleFromInput = Console.ReadLine();

            // store input values for professors
            var newProfessor = new Professors
            {
                NewProfessorName = professorNameFromInput,
                NewProfessorTitle = professorTitleFromInput
            };
            return newProfessor;
        }

        // insert course values into db
        public static void InsertCourse(SqlConnection conn, Courses newCourse)
        {
            var _insert = "INSERT INTO Courses (Name, Number, CourseLevel, Room, StartTime)" +
            " VALUES (@Name, @Number, @CourseLevel, @Room, @StartTime)";
            var cmd = new SqlCommand(_insert, conn);

            cmd.Parameters.AddWithValue("Name", newCourse.NewCourseName);
            cmd.Parameters.AddWithValue("Number", newCourse.NewCourseNumber);
            cmd.Parameters.AddWithValue("CourseLevel", newCourse.NewCourseLevel);
            cmd.Parameters.AddWithValue("Room", newCourse.NewCourseRoom);
            cmd.Parameters.AddWithValue("StartTime", newCourse.NewCourseLevel);
            cmd.ExecuteScalar();
        }
        // insert professor values into db
        public static void InsertProfessor(SqlConnection conn, Professors newProfessor)
        {
            var _insert = "INSERT INTO Professors (Name, Title)" +
            " VALUES (@Name, @Title)";
            var cmd = new SqlCommand(_insert, conn);

            cmd.Parameters.AddWithValue("Name", newProfessor.NewProfessorName);
            cmd.Parameters.AddWithValue("Title", newProfessor.NewProfessorTitle);
            cmd.ExecuteScalar();
        }
        // display all courses that are in db
        public static List<Courses> GetAllCourses(SqlConnection conn)
        {
            var _select = "SELECT [ID], [Name], [Number], [CourseLevel], [Room], [StartTime]" +
                " FROM Courses";
            var query = new SqlCommand(_select, conn);
            var reader = query.ExecuteReader();
            var _rv = new List<Courses>();
            // parse results
            while (reader.Read())
            {
                var _newCourse = new Courses(reader);
                Console.WriteLine($"Course Name: {_newCourse.NewCourseName}, Course Number: {_newCourse.NewCourseNumber}," +
                    $"Course Level: {_newCourse.NewCourseLevel}, Course Room: {_newCourse.NewCourseRoom}, Start Time: {_newCourse.NewCourseTime}");
            }
            reader.Close();
            return _rv;

        }
        // display all professors that are in db
        public static List<Professors> GetAllProfessors(SqlConnection conn)
        {
            var _select = "SELECT [ID], [Name], [Title] FROM Professors";
            var query = new SqlCommand(_select, conn);
            var reader = query.ExecuteReader();
            var _rv = new List<Professors>();
            // parse results
            while (reader.Read())
            {
                var _newProfessor = new Professors(reader);
                Console.WriteLine($"Professor's Name: {_newProfessor.NewProfessorName}, Professor's Title: {_newProfessor.NewProfessorTitle}");
            }
            reader.Close();
            return _rv;
        }
        // view enrolled students
        public static List<Courses> ViewEnrolled(SqlConnection conn)
        {
            var _select = "SELECT Courses.Name, Courses.Number, Courses.CourseLevel, Students.FullName as Student" +
                " FROM Courses" +
                " JOIN StudentEnrollments ON StudentEnrollments.FKCoursesID = Courses.ID" +
                " JOIN Students ON StudentEnrollments.FKStudentsID = Students.ID";

            var query = new SqlCommand(_select, conn);
            var reader = query.ExecuteReader();
            var _rv = new List<Courses>();
            while (reader.Read())
            {
                var enrolled = new Courses(reader);
                Console.WriteLine($"{enrolled.Student} is enrolled in Course Name: {enrolled.NewCourseName}, " +
                    $"Course Number: {enrolled.NewCourseNumber}, Course Level: {enrolled.NewCourseLevel} this term."); 
            }
            reader.Close();
            return _rv;
        }
        public static List<Courses>GetAllCourseInfo(SqlConnection conn)
        {
            var _select = "SELECT Courses.Name, Courses.Number Courses.Room, Professor.Name as Professor" +
                "Students.FullName as Student" +
                "FROM Courses" +
                " FULL JOIN ClassesTaught ON ClassesTaught.FKCourseID = Courses.ID" +
                " FULL JOIN Professors ON ClassesTaught.FKProfessorID = Professors.ID" +
                " FULL JOIN StudentEnrollments ON StudentEnrollments.FKCourseID = Courses.ID" +
                " FULL JOIN Students ON StudentEnrollments.Students.ID";

            var query = new SqlCommand(_select, conn);
            var reader = query.ExecuteReader();
            var _rv = new List<Courses>();
            while (reader.Read())
            {
                var courseData = new Courses(reader);
                Console.WriteLine($"ourse Info: {courseData.NewCourseName}, {courseData.NewCourseNumber}, {courseData.NewCourseRoom}, {courseData.Professor}, {courseData.Student}");
            }
            reader.Close();
            return _rv;
        }
    }
}


    

