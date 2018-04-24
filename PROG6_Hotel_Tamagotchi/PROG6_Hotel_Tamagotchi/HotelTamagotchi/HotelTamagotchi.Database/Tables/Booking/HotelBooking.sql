CREATE TABLE [dbo].[HotelBooking]
(
	
	[HotelRoomId] INT NOT NULL PRIMARY KEY,
	CONSTRAINT [FK_HotelBooking_HotelRoom] FOREIGN KEY ([HotelRoomId]) REFERENCES [dbo].[HotelRoom] ([HotelRoomId]) ON DELETE CASCADE,

)
