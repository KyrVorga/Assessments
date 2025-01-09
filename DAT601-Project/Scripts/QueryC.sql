-- Write SQL to be used to insert data from a 3D sensor to its stored data on the Spaces database.
-- The transaction receives the 3D sensor ID and all the data from a data stream. That is made up
-- of one or more records of 3D human imagery – texture, body shape and estimated skeletal points
-- Human voice, Shared audio from other sources, time, longitude, latitude, and altitude.



USE DAT601ProjectMS3;
GO

DROP PROCEDURE IF EXISTS AddSensorData;
GO

CREATE PROCEDURE AddSensorData
	@SensorID int,
	@ZoneID int,
	@ContractID int,
	@VideoFile Image,
	@AudioFIle Image,
	@SkeletalPoints Image,
	@BodyShape Image,
	@Texture Image
AS

	INSERT INTO [Data] 
		(OwnerID, ZoneID, SensorID, CreationTime)
	VALUES
		(@ContractID, @ZoneID, @SensorID, GETDATE());
	
	
	INSERT INTO Video 
		(DataID, VideoFile)
	VALUES
		(IDENT_CURRENT('Data'), @VideoFile);
	
	
	INSERT INTO Audio 
		(DataID, AudioFile)
	VALUES
		(IDENT_CURRENT('Data'), @AudioFIle );
	
	
	INSERT INTO [3DImagery]  
		(DataID, SkeletalPoints, BodyShape, Texture)
	VALUES
		(IDENT_CURRENT('Data'), @SkeletalPoints, @BodyShape, @Texture);
GO

EXECUTE AddSensorData
	@SensorID = 925,
	@ZoneID = 333,
	@ContractID = 884,
	@VideoFile ='https://robohash.org/voluptatemquiet.png?size=50x50&set=set1',
	@AudioFIle ='https://robohash.org/voluptatemquiet.png?size=50x50&set=set1',
	@SkeletalPoints ='https://robohash.org/voluptatemquiet.png?size=50x50&set=set1',
	@BodyShape ='https://robohash.org/voluptatemquiet.png?size=50x50&set=set1',
	@Texture = 'https://robohash.org/voluptatemquiet.png?size=50x50&set=set1';
GO



-- Get a list of occurences for each sensor since mockaroo duplicates things lots...
--SELECT c.SensorID, COUNT(c.SensorID) as sc  FROM ZoneSensor zs
--JOIN contract c ON c.SensorID = zs.SensorID 
--GROUP BY c.SensorID
--ORDER BY sc ASC;



-- Get the information about that sensor.
--SELECT * FROM ZoneSensor zs
--JOIN contract c ON c.SensorID = zs.SensorID 
--WHERE c.SensorID = 925;
