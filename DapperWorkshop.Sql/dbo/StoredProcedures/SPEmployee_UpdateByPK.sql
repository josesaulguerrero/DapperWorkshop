CREATE PROCEDURE [dbo].[SPEmployee_UpdateByPK]
	@Id INT,
	@Name NVARCHAR(500),
	@Email VARCHAR(255),
	@Age INT,
	@FiredAt DATETIME = NULL
AS
BEGIN
	UPDATE dbo.[Employee]
	SET Name = @Name, Email = @Email, Age = @Age, FiredAt = @FiredAt
	WHERE Id = @Id
END