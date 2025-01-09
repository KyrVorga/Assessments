-- For each salesperson list the subscribers they have sold a subscription to.
-- The transaction receives the salesperson's name as input, and presents each
-- subscriber's name, address, and the % they were discounted.


USE DAT601ProjectMS3;
GO

DROP PROCEDURE IF EXISTS GetSalespersonSubscribers;
GO

CREATE PROCEDURE GetSalespersonSubscribers
	@GivenName varchar(50), 
	@LastName varchar(50)
AS


	SELECT s1.GivenName, s1.LastName, s1.Address FROM Subscriber s1
	JOIN Contract c ON c.SubscriberID = s1.SubscriberID 
	JOIN Salesperson s2 ON s2.SalespersonID = c.SalespersonID
	JOIN Staff s3 ON s3.StaffID = s2.StaffID
	WHERE s3.GivenName = @GivenName AND 
		  s3.LastName = @LastName;
GO


EXECUTE GetSalespersonSubscribers
	@GivenName = 'Hector',
	@LastName = 'Bim'
GO



--SELECT * FROM Staff 
--RIGHT JOIN Salesperson
--	ON Staff.StaffID = Salesperson.StaffID
--	WHERE SalespersonID = 265;
--	
--
-- this shows how many subscribers each salesperson has sold to, good for testing the procedure.
--SELECT s2.SalespersonID, Count(s2.SalespersonID) AS scount FROM Subscriber s1
--JOIN Contract c ON c.SubscriberID = s1.SubscriberID 
--JOIN Salesperson s2 ON s2.SalespersonID = c.SalespersonID
--JOIN Staff s3 ON s3.StaffID = s2.StaffID
--GROUP BY s2.SalespersonID 
--ORDER BY scount DESC;