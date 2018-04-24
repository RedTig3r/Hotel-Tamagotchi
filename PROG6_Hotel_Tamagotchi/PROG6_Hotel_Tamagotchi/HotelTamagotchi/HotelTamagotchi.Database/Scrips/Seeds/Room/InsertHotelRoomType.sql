MERGE INTO [dbo].[HotelRoomType]  AS Target  
 USING (VALUES
 	('Rest room', 10),
 	('Game room' , 20),
 	('Fight room', 20),
 	('Work room', 0),
	('Love room', 30)
 ) AS Source (RoomType,RoomTypeCost)
 ON Target.RoomType = Source.RoomType 
 WHEN NOT MATCHED BY TARGET THEN  
 	INSERT (RoomType,RoomTypeCost) 
 	VALUES (RoomType,RoomTypeCost)  
 WHEN MATCHED THEN
 	UPDATE SET
 		RoomType = Source.RoomType,
		RoomTypeCost = Source.RoomTypeCost;