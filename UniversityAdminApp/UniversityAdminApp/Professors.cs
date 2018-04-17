using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAdminApp

{
    class Professors
    {
        public int ID { get; set; }
        public string NewProfessorName { get; set; }
        public string NewProfessorTitle { get; set; }

        // empty constructor for new instance
        public Professors()
        {

        }

        // read input 
        public Professors(SqlDataReader reader)
        {
            ID = (int)reader["ID"];
            NewProfessorName = reader["Name"].ToString();
            NewProfessorTitle = reader["Title"].ToString();
        }

    }
}



