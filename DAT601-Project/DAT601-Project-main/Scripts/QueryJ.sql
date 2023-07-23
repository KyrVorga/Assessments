-- Display the total cost of all parts replaced in maintenance of a 3D sensor.
-- The transaction displays the 3D sensor ID, Total Cost of replaced parts,
-- for every 3D sensor.





USE DAT601ProjectMS3;
GO

DROP PROCEDURE IF EXISTS GetSensorReplacedParts;
GO

CREATE PROCEDURE GetSensorReplacedParts
	@SensorID int
AS

	SELECT s.SensorID, p.PartID, p.ReplacementDate
	FROM Sensor s 
	JOIN Part p ON p.SensorID = s.SensorID 
	WHERE p.ReplacementPartID IS NOT NULL
	order by SensorID asc, PartID asc;

GO


EXECUTE GetSensorReplacedParts
	@SensorID = 10
GO


