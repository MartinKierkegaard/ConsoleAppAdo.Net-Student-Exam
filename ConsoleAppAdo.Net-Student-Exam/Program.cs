using System;
using System.Collections.Generic;

namespace ConsoleAppAdo.Net_Student_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            FacadeStudent.InsertNewStudentStoredProcedure("My","34566");

            FacadeStudent.InsertNewStudent("Tom", "37762");


            foreach (var studentgrade in FacadeStudent.GetSpecificStudentsGrades(230))
            {
                Console.WriteLine(studentgrade);
            }

            List<Student> liste = new List<Student>();



            foreach (var item in FacadeStudent.GetAllStudents())
            {
                Console.WriteLine($"navn: {item.Navn} mobilnr: {item.MobilNr} ");
            }

            Console.WriteLine("All students and all grades");

            foreach (var studentgrade in FacadeStudent.GetAllStudentsGrades())
            {
                Console.WriteLine(studentgrade);
            }


            Console.ReadLine();
        }
    }
}
