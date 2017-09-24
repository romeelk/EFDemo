 CREATE PROCEDURE [dbo].[GetStudents]     
    AS
    BEGIN
    SET NOCOUNT ON;

    SELECT StudentId, FirstName, LastName, Age, GradeId
    FROM Student
    END