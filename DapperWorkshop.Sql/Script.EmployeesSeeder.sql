IF NOT EXISTS (select 1 from dbo.[Employee])
BEGIN 
	INSERT INTO dbo.[Employee] 
		(Name, EmployeeCode, Email, Age, HiredAt)
	VALUES 
		('Jose', '1223', 'jose.guerrero@dapper.com', 19, GETDATE()),
		('Tanya', '1452', 'tanya.sereda@dapper.com', 21, GETDATE());
END