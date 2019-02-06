namespace ConsoleAppAdo.Net_Student_Exam
{
    public class StudentGrade
    {
        public StudentGrade()
        {
        }

        public int StudentId { get; set; }
        public string Navn { get; set; }
        public int Grade { get; set; }


        public override string ToString()
        {
            return $"StudentId: {StudentId.ToString()}, Navn: {Navn}, Grade {Grade.ToString()}  ";
        }
    }
}