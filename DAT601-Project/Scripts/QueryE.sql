--For a contract list all the data collected. The transaction receives the contracting
--organisation'sname and presents for each collected data record, the contracting
--organisation's name, a 3D sensor ID, 3D human imagery – texture, body shape AND
--estimated skeletal points, Human voice, Shared audio from other sources, time,
--longitude, latitude, and altitude




USE DAT601ProjectMS3;
GO

DROP PROCEDURE IF EXISTS GetAllContractData;
GO

CREATE PROCEDURE GetAllContractData
	@GivenName varchar(50), 
	@LastName varchar(50)
AS

	-- another instance of mockdata producing duplicates. the subclasses
	-- of data have multiple instances of dataID when there should only be one.

	SELECT CONCAT(s.GivenName, ' ', s.LastName) AS Name, s1.SensorID, v.VideoFile, a.AudioFile, d2.SkeletalPoints, d2.BodyShape, d2.Texture, sl.Longitude, sl.Latitude, sl.Altitude, d.CreationTime , d.DataID  
	FROM Subscriber s 
	JOIN Contract c ON c.SubscriberID = s.SubscriberID 
	JOIN [Data] d ON d.OwnerID  = c.ContractID  
	JOIN Video v ON v.DataID = d.DataID 
	JOIN Audio a ON a.DataID = d.DataID 
	JOIN [3DImagery] d2 ON d2.DataID = d.DataID
	JOIN Sensor s1 ON d.SensorID = s1.SensorID 
	JOIN SensorLocation sl ON sl.SensorID = s1.SensorID 
	WHERE s.GivenName = @GivenName AND s.LastName = @LastName
	ORDER BY s1.SensorID ;

GO


EXECUTE GetAllContractData
	@GivenName = 'Lennie',
	@LastName = 'Widdocks'
GO





-- select * from Audio where DataID = 235