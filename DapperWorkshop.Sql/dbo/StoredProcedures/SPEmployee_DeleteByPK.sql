CREATE PROCEDURE [dbo].[SPEmployee_DeleteByPK]
	@Id int,
	@FiredAt DATETIME
AS
BEGIN
	UPDATE dbo.[Employee]
	SET FiredAt = @FiredAt
	WHERE Id = @Id;
END
