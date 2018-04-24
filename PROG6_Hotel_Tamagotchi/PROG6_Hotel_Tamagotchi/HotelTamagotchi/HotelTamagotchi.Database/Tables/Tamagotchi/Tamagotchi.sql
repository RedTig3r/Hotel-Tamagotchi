CREATE TABLE [dbo].[Tamagotchi]
(
	[TamagotchiId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(10) NOT NULL , 
    [IsALive] BIT NOT NULL,
	[Age] INT NOT NULL CHECK ([Age]>=0), 
	[Money] INT NOT NULL CHECK ([Money]>=0), 
	[Level] INT NOT NULL CHECK ([Level]>=0), 
	[Health] INT NOT NULL CHECK ([Health]>=0), 
	[Boredom] INT NOT NULL CHECK ([Boredom]>=0),
	[PlayerUserId] INT NOT NULL,
	[HotelRoomId] INT NULL,
	CONSTRAINT [FK_Tamagotchi_PlayerUser] FOREIGN KEY ([PlayerUserId]) REFERENCES [dbo].[PlayerUser] ([PlayerUserId]) ON DELETE CASCADE,
	CONSTRAINT [FK_Tamagotchi_HotelBooking] FOREIGN KEY ([HotelRoomId]) REFERENCES [dbo].[HotelBooking] ([HotelRoomId]) ON DELETE CASCADE,

)
