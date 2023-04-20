DELIMITER //
Create Procedure GetStudents()
Begin
	Select 
		Student.StudentId,
        Student.FirstName,
        Student.LastName,
        Student.Email,
        Student.Gender,
        Collage.Name As CollageName,
        City.CityName
	From
		Student
        Join Collage
        on Collage.CollageId = Student.CollageId
        Join City
        on City.CityId = Student.CityId;
End //
DELIMITER;

DELIMITER //
Create Procedure GetStudentById
(
	In StudentId int
)
Begin
	Select 
		Student.StudentId,
        Student.FirstName,
        Student.LastName,
        Student.Email,
        Student.Gender,
        Collage.Name As CollageName,
        City.CityName
	From
		Student
        Join Collage
        on Collage.CollageId = Student.CollageId
        Join City
        on City.CityId = Student.CityId
	Where 
		Student.StudentId = StudentId;
End //
DELIMITER;

Delimiter //
Create Procedure AddStudent
(
	In FirstName nvarchar(50),
    In LastName nvarchar(50),
    In Email nvarchar(50),
    In Gender nvarchar(50),
    In CollageId int,
    In CityId int
)
Begin
	Insert into Student
		(
			FirstName,
            LastName,
            Email,
            Gender,
            CollageId,
            CityId
        )
	values
		(
			FirstName,
            LastName,
            Email,
            Gender,
            CollageId,
            CityId
        );
End //
Delimiter;

Delimiter //
Create Procedure UpdateStudent
(
	In StudentId int,
	In FirstName nvarchar(50),
    In LastName nvarchar(50),
    In Email nvarchar(50),
    In Gender nvarchar(50),
    In CollageId int,
    In CityId int
)
Begin
	Update Student
	Set
		Student.FirstName = FirstName,
		Student.LastName = LastName,
		Student.Email = Email,
		Student.Gender = Gender,
		Student.CollageId = CollageId,
		Student.CityId = CityId
	Where
		Student.StudentId = StudentId;
End //
Delimiter;

Delimiter //
Create Procedure DeleteStudent
(
	In StudentId int
)
Begin
	Delete From Student
	Where
		Student.StudentId = StudentId;
End //
Delimiter;