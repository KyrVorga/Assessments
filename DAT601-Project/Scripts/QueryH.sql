-- Update the location and Zone of a 3D sensor. The transaction receives the 3D sensor ID,
-- a location and a Zone expressed as a list of coordinates in latitude, longitude pairs.
-- It updates the location of the 3D sensor and its corresponding Zone.
-- (This transaction may require more than one update query.)


USE DAT601ProjectMS3;
GO

DROP PROCEDURE IF EXISTS DeleteContractData;
GO

CREATE PROCEDURE DeleteContractData
	@SensorID int,
	@ZoneID int,
	@Longitude decimal(9,6),
	@Latitude decimal(8,6),
	@Altitude decimal(11,1)
AS

	INSERT INTO SensorLocation 
		(SensorID, Date, Longitude, Latitude, Altitude)
	VALUES
		(@SensorID, GETDATE(), @Longitude, @Latitude, @Altitude)

	UPDATE ZoneSensor 
	SET ZoneID = @ZoneID
	WHERE SensorID = @SensorID;

GO


EXECUTE DeleteContractData
	@SensorID = 150,
	@ZoneID = 50,
	@Longitude = 113.672784,
	@Latitude = 57.0684709,
	@Altitude = 81.3
GO



-- sensor location tracks the history of its location,
-- so the most recent date is the one inserted.

SELECT s.SensorID, sl.Date, sl.Latitude, sl.Longitude, sl.Altitude
FROM Sensor s 
JOIN SensorLocation sl ON sl.SensorID = s.SensorID 
WHERE s.SensorID = 150
order by [Date] desc;