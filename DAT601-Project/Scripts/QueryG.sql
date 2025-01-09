--For a given 3D sensor list all the suppliers of parts.
--The transaction receives the 3D sensor ID, and presents
--the Supplier Name and, Part Name.


-- I forgot to make replacementDate mostly null values when generating.


USE DAT601ProjectMS3;
GO

DROP PROCEDURE IF EXISTS GetSuppliersOfSensor;
GO

CREATE PROCEDURE GetSuppliersOfSensor
	@SensorID int
AS

	SELECT s.SensorID, s2.CompanyName, p.PartID, p.PartNumber FROM Sensor s 
	JOIN Part p ON p.SensorID = s.SensorID 
	JOIN Supplier s2 ON s2.SupplierID = p.SupplierID
	WHERE p.ReplacementDate IS NULL AND
		  p.ReplacementPartID IS NULL AND
		  s.SensorID = @SensorID
	ORDER BY p.PartID

GO


EXECUTE GetSuppliersOfSensor
	@SensorID = 1
GO