CREATE TABLE [dbo].[HotelRoom]
(
  [HotelRoomId]	INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [HotelRoomName] NVARCHAR(50) NOT NULL,
  [RoomSize] INT NOT NULL,
  [RoomType] NVARCHAR(50) NOT NULL,
  CONSTRAINT [FK_HotelRoom_HotelRoomType] FOREIGN KEY ([RoomType]) REFERENCES [dbo].[HotelRoomType] ([RoomType]) ON DELETE CASCADE,
  CONSTRAINT [FK_HotelRoom_NumberOfBeds] FOREIGN KEY ([RoomSize]) REFERENCES [dbo].[HotelRoomSize] ([RoomSize]) ON DELETE CASCADE,

)
