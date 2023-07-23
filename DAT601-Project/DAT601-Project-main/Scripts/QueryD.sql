--List the location in latitude, longitude coordinates, of each 3D sensor that
--is currently in a contract (subscribed to). The transaction presents the 
--Contracting organisation or person’s name, a 3D sensor ID, a Latitude, and a Longitude.



USE DAT601ProjectMS3;
GO

DROP PROCEDURE IF EXISTS GetAllSensorLocation;
GO

CREATE PROCEDURE GetAllSensorLocation
AS


	-- Duplicates that are shown in the query are due to mockaroo
	-- using the same sensorID multiple times in the contract table.
	-- The query is correct for this database.

	SELECT CONCAT(s2.GivenName, ' ', s2.LastName) AS Name,c.ContractID,  s.SensorID, sl.Longitude, sl.Latitude, sl.Altitude
	FROM Sensor s
	JOIN SensorLocation sl ON sl.SensorID = s.SensorID 
	JOIN Contract c ON c.SensorID = s.SensorID 
	JOIN Subscriber s2 ON s2.SubscriberID = c.SubscriberID
	WHERE sl.[Date] = (SELECT MAX(sl2.[Date])
					   FROM SensorLocation sl2 
					   WHERE sl2.SensorID = s.SensorID 
						)
	ORDER BY s.SensorID;
GO



EXECUTE GetAllSensorLocation
GO