using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAppAdo.Net_Student_Exam
{
    public static class FacadeStudent
    {
        private static string conn = "Server=tcp:zea2019.database.windows.net,1433;Initial Catalog=student;Persist Security Info=False;User ID=martin;Password=Roskilde1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static List<Student> GetAllStudents()
        {
            string sql = "Select * from student";

            var result = new List<Student>();
            using (var databaseConnection = new SqlConnection(conn))
            {
                databaseConnection.Open();
                using (var selectCommand = new SqlCommand(sql, databaseConnection))
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int studentid = reader.GetInt32(0);
                                string navn = reader.GetString(1);
                                string mobilnr = reader.GetString(2);

                                var Student = new Student()
                                {
                                    StudentId = studentid,
                                    Navn = navn,
                                    MobilNr = mobilnr
                                };

                                result.Add(Student);
                            }
                        }
                    }
                return result;
            }
        }



    }
}
