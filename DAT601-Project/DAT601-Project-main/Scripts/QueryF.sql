-- For each 3D sensor present the list of subscribers who are viewing a live
-- 3D video stream. The transaction lists 3D sensor ID, Subscriber Name, Stream ID.

-- I didnt model this into my database, so here is the next closest thing.
-- My database stores a log of all the actions performed by a user, including
-- viewing data.




-- this query shows for each sensor, when a resource (I cant specify video)
-- was most recently accessed. The procedure returns the sensor Id, the subscriber's
-- name, the action they took (view), they time performed and the dataID they accessed.

USE DAT601ProjectMS3;
GO

DROP PROCEDURE IF EXISTS GetViewingSubscribers;
GO

CREATE PROCEDURE GetViewingSubscribers
AS

	SELECT s.SensorID, CONCAT(s2.GivenName, ' ', s2.LastName) AS Name, aa.ActionName, al.TimePerformed, al.DataID
	FROM Sensor s 
	JOIN Contract c ON c.SensorID = s.SensorID 
	JOIN Subscriber s2 ON s2.SubscriberID = c.SubscriberID 
	JOIN Subscription s3 ON s3.ContractID = c.ContractID 
	JOIN AccessLog al ON al.SubscriptionID = s3.SubscriptionID 
	JOIN AccessAction aa ON aa.ActionID = al.ActionID
	WHERE aa.ActionName = 'View' AND 
		  al.TimePerformed = (SELECT MAX(al2.TimePerformed)
					  	      FROM AccessLog al2 
						      WHERE al2.ActionID = al.ActionID AND
						     		al2.SubscriptionID = al.SubscriptionID
							 )
	ORDER BY s.SensorID ASC;
	
		 
GO


EXECUTE GetViewingSubscribers
GO
