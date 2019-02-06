using System;
using System.Collections.Generic;

namespace ConsoleAppAdo.Net_Student_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Student> liste = new List<Student>();

            liste = FacadeStudent.GetAllStudents();


            foreach (var item in liste)
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
