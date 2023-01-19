CREATE PROCEDURE [dbo].[SPEmployee_SelectByPK]
	@Id int
AS
BEGIN
	SELECT *
	FROM dbo.[Employee]
	WHERE Id = @Id;
END
