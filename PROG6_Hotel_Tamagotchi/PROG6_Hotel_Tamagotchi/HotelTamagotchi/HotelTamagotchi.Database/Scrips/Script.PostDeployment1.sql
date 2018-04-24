/*
 Post-Deployment Script Template							
 --------------------------------------------------------------------------------------
  This file contains SQL statements that will be appended to the build script.		
  Use SQLCMD syntax to include a file in the post-deployment script.			
  Example:      :r .\myfile.sql								
  Use SQLCMD syntax to reference a variable in the post-deployment script.		
  Example:      :setvar TableName MyTable							
                SELECT * FROM [$(TableName)]					
 --------------------------------------------------------------------------------------
 */
 -- Tamagotchi
:r .\Seeds\Tamagotchi\InsertPlayerUser.sql
:r .\Seeds\Tamagotchi\InsertTamagotchi.sql

 -- Room
:r .\Seeds\Room\InsertHotelRoomType.sql
:r .\Seeds\Room\InsertHotelRoomSize.sql
:r .\Seeds\Room\InsertHotelRoom.sql
 