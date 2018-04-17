using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAdminApp
{
    class Courses
        // Declare class, fields
    {
        public int ID { get; set; }
        public string NewCourseNumber { get; set; }
        public string NewCourseLevel { get; set; }
        public string NewCourseName { get; set; }
        public string NewCourseRoom { get; set; }
        public string NewCourseTime { get; set; }
        public string Student { get; set; }
        public string Professor { get; set; }

        // empty constructor for new instance
        public Courses()
        {

        }

         public Courses(SqlDataReader reader)
        {
            ID = (int)reader["ID"];
            NewCourseNumber = reader["Name"].ToString();
            NewCourseLevel = reader["CourseLevel"].ToString();
            NewCourseNumber = reader["Number"].ToString();
            NewCourseRoom = reader["Room"].ToString();
            NewCourseTime = reader["StartTime"].ToString();
        }
        
    }
}

//factory insert course conn, newCourse
