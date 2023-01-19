CREATE PROCEDURE [dbo].[SPEmployee_Insert]
	@Name NVARCHAR(500),
	@EmployeeCode VARCHAR(4),
	@Email VARCHAR(255),
	@Age INT,
	@HiredAt DATETIME
AS
BEGIN 
	INSERT INTO dbo.[Employee] 
		(Name, EmployeeCode, Email, Age, HiredAt)
	VALUES (@Name, @EmployeeCode, @Email, @Age, @HiredAt);
END
