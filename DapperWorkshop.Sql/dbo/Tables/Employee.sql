CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(500) NOT NULL,
	[EmployeeCode] VARCHAR(4) NOT NULL,
	[Email] VARCHAR(255) NOT NULL,
	[Age] INT NOT NULL,
	[HiredAt] DATETIME NOT NULL,
	[FiredAt] DATETIME NULL
)
