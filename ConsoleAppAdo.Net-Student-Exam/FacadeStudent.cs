using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAppAdo.Net_Student_Exam
{
    public static class FacadeStudent
    {
        private static string conn = "Server=tcp:zea2019.database.windows.net,1433;Initial Catalog=student;Persist Security Info=False;User ID=martin;Password=Roskilde1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        /// <summary>
        /// metode som henter alle students fra Azure Database
        /// </summary>
        /// <returns>List<Student></returns>
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

        public static List<StudentGrade> GetAllStudentsGrades()
        {
            string sqlStoredProcedure = "GetAllStudentGrade";

            var result = new List<StudentGrade>();
            using (var databaseConnection = new SqlConnection(conn))
            {
                databaseConnection.Open();
                using (var storedProcedureCommand = new SqlCommand(sqlStoredProcedure, databaseConnection))
                {
                    //fortæller at det et en stored procedure der skal kaldes
                    storedProcedureCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = storedProcedureCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string navn = reader.GetString(0);
                                int studentid = reader.GetInt32(1);
                                int grade = reader.GetInt32(2);

                                var StudentGrade = new StudentGrade()
                                {
                                    StudentId = studentid,
                                    Navn = navn,
                                    Grade = grade
                                };

                                result.Add(StudentGrade);
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Metode som henter en specifik studerende med givne karakterer
        /// </summary>
        /// <param name="studentId">stdentid som der skal fremfindes</param>
        /// <returns> List<StudentGrade></returns>
        public static List<StudentGrade> GetSpecificStudentsGrades(int studentId)
        {
            string sqlStoredProcedure = "GetSpecificStudentGrade";

            var result = new List<StudentGrade>();
            using (var databaseConnection = new SqlConnection(conn))
            {
                databaseConnection.Open();
                using (var storedProcedureCommand = new SqlCommand(sqlStoredProcedure, databaseConnection))
                {
                    //fortæller at det et en stored procedure der skal kaldes
                    storedProcedureCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    storedProcedureCommand.Parameters.AddWithValue("@StudentId", studentId);

                    using (SqlDataReader reader = storedProcedureCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string navn = reader.GetString(0);
                                int studentid = reader.GetInt32(1);
                                int grade = reader.GetInt32(2);

                                var StudentGrade = new StudentGrade()
                                {
                                    StudentId = studentid,
                                    Navn = navn,
                                    Grade = grade
                                };

                                result.Add(StudentGrade);
                            }
                        }
                    }
                }
            }

            return result;
        }



        /// <summary>
        /// Indsætter en ny student via SQL 
        /// </summary>
        /// <param name="navn">navn</param>
        /// <param name="mobilnr">mobilnr</param>
        public static void InsertNewStudent(string navn, string mobilnr)
        {
            string sql = "Insert INTO Student (Name,mobilnr) values (@navn,@mobilnr)";
            using (var databaseConnection = new SqlConnection(conn))
            {
                databaseConnection.Open();
                using (var insertCommand = new SqlCommand(sql, databaseConnection))
                {
                    //fortæller at det et en stored procedure der skal kaldes
                    insertCommand.CommandType = System.Data.CommandType.Text;
                    insertCommand.Parameters.AddWithValue("@Navn", navn);
                    insertCommand.Parameters.AddWithValue("@MobilNr", mobilnr);

                    int rowsaffected = insertCommand.ExecuteNonQuery();

                    Console.WriteLine($"$Insert : {rowsaffected}");
                }
            }
        }

        /// <summary>
        /// Indsætter en ny student via Stored procedure
        /// </summary>
        /// <param name="navn"></param>
        /// <param name="mobilnr"></param>
        public static void InsertNewStudentStoredProcedure(string navn, string mobilnr)
        {
            string sqlStoredProcedure = "AddPerson";
            using (var databaseConnection = new SqlConnection(conn))
            {
                databaseConnection.Open();
                using (var storedProcedureCommand = new SqlCommand(sqlStoredProcedure, databaseConnection))
                {
                    //fortæller at det et en stored procedure der skal kaldes
                    storedProcedureCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    storedProcedureCommand.Parameters.AddWithValue("@Name", navn);
                    storedProcedureCommand.Parameters.AddWithValue("@MobilNr", mobilnr);
                    
                    int rowaffected = storedProcedureCommand.ExecuteNonQuery();

                    Console.WriteLine($"$Insert : {rowaffected}");
                }
            }
        }



    }
}
