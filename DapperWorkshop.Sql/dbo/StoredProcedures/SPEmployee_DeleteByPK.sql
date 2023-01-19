CREATE PROCEDURE [dbo].[SPEmployee_DeleteByPK]
	@Id int
AS
BEGIN
	DELETE
	FROM dbo.[Employee]
	WHERE Id = @Id;
END
