# ConsoleAppAdo.Net-Student-Exam
Eksempel på brug af Ado.net til at kalde en database på Azure

## I Facade Student er der følgende metoder
* **GetAllStudent()**, som henter alle studerende via SQL
* **GetAllStudentGrade()**, som henter alle studerende og karakter via stored procedure
* **GetSpecificStudentsGrades(int studentId)**, som henter en specifik studerende via en stored procedure
* **InsertNewStudent(string navn, string mobilnr)**, som indsætter en ny student i databasen via SQL
* **InsertNewStudentStoredProcedure(string navn, string mobilnr)**, som indsætter en ny student i databasen via en stored procedure

Database script til tabeller og stored procedures samt demo data kan findes i dette gitHub repo
[GitHub](https://github.com/MartinKierkegaard/StudentExamDB)
:octocat:

