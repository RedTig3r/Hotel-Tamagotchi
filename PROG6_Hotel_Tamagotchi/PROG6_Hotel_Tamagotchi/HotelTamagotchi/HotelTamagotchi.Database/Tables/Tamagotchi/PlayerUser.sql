CREATE TABLE [dbo].[PlayerUser]
(
	[PlayerUserId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	[PlayerUserName] NVARCHAR(50) NOT NULL,
	[PlayerUserRoll] NVARCHAR(50) NOT NULL,
)
