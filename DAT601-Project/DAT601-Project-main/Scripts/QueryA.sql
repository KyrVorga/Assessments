-- A salesperson subscribes to a new standard subscription to a 3D sensor.
-- The transaction receives the salesperson Id, a discount %, all subscriber
-- details, and a 3D sensor ID.


USE DAT601ProjectMS3;
GO

DROP PROCEDURE IF EXISTS NewSubscription;
GO

CREATE PROCEDURE NewSubscription
	@GivenName varchar(50), 
	@LastName varchar(50), 
	@Email varchar(100), 
	@WorkPhone varchar(20), 
	@PersonalPhone varchar(20), 
	@Address varchar(200), 
	@Postcode varchar(15), 
	@CityID int,
	@SalespersonID int,
	@SensorID int,
	@SubscriptionTypeID int,
	@ExecutiveID int
AS

	INSERT INTO Subscriber
	    (GivenName, LastName, Email, WorkPhone, PersonalPhone, Address, Postcode, CityID)
	VALUES 
		(@GivenName,@LastName,@Email,@WorkPhone,@PersonalPhone,@Address, @Postcode,@CityID);
	
	
	INSERT INTO Contract
		(WrittenDate, EffectiveDate, SensorID, SubscriberID, SalespersonID, ExecutiveID)
	VALUES	
		(GETDATE(),GETDATE(), @SensorID, IDENT_CURRENT('Subscriber'), @SalespersonID, @ExecutiveID);
	
	INSERT INTO Subscription 
		(SubscriptionTypeID, ContractID, SubscriptionStart)
	VALUES
		(@SubscriptionTypeID, IDENT_CURRENT('Contract'), GETDATE());
GO



EXECUTE NewSubscription
	@GivenName = 'Brand',
	@LastName = 'Albrecht',
	@Email = 'Brand@Albrecht.com',
	@WorkPhone ='8434381134',
	@PersonalPhone = '2624155099',
	@Address = '10 Hill Road',
	@Postcode = '55160',
	@CityID = 18, 
	@SalespersonID = 221, 
	@SensorID = 569,
	@SubscriptionTypeID = 1,
	@ExecutiveID = 1;
GO
