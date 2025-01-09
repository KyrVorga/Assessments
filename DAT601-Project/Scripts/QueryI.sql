-- Delete the data collected for a given Contract. The transaction 
-- receives a Contract ID, the data collected for a Contract is deleted.



USE DAT601ProjectMS3;
GO

DROP PROCEDURE IF EXISTS DeleteContractData;
GO

CREATE PROCEDURE DeleteContractData
	@ContractID int
AS

	WHILE ISNULL((SELECT TOP(1) DataID FROM [Data] WHERE OwnerID = @ContractID), 0) != 0 
	BEGIN 
		
		DECLARE @DataID int;
		SELECT TOP(1) @DataID =  DataID FROM [Data] WHERE OwnerID = @ContractID;
		
		DELETE FROM AccessLog
		WHERE DataID = @DataID;
		
		DELETE FROM Video 
		WHERE DataID = @DataID;
		
		DELETE FROM Audio 
		WHERE DataID = @DataID;
		
		DELETE FROM [3DImagery] 
		WHERE DataID = @DataID;
		
		DELETE FROM [Data] 
		WHERE DataID = @DataID;
	
	END
	

	DELETE FROM [Data]
	WHERE OwnerID = @ContractID;

GO


EXECUTE DeleteContractData
	@ContractID = 44
GO


