MERGE INTO [dbo].[HotelRoomSize]  AS Target  
 USING (VALUES
 	(2),
 	(3),
 	(5)
 ) AS Source (RoomSize)
 ON Target.RoomSize = Source.RoomSize 
 WHEN NOT MATCHED BY TARGET THEN  
 	INSERT (RoomSize) 
 	VALUES (RoomSize)  
 WHEN MATCHED THEN
 	UPDATE SET
 		RoomSize = Source.RoomSize; 