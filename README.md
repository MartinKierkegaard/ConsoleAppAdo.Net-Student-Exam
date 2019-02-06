# ConsoleAppAdo.Net-Student-Exam
Eksempel på brug af Ado.net til at kalde en database på Azure

##I Facade Student er der følgende metoder
* GetAllStudent, som henter alle studerende vai SQL
* GetAllStudentGrade, som henter alle studerende og karakter vai stored procedure
* GetSpecificStudentsGrades(int studentId), som henter en spcifik studerende via stored procedure
* InsertNewStudent(string navn, string mobilnr), som indsætter en ny student i databasen via SQL
* InsertNewStudentStoredProcedure(string navn, string mobilnr), som indsætter en ny student i databasen via stored procedure

Database script til tabeller og stored procedures samt demo data kan findes i dette gitHub repo
[GitHub](https://github.com/MartinKierkegaard/StudentExamDB)


