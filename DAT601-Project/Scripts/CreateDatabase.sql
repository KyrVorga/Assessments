USE master;
GO

DROP DATABASE IF EXISTS DAT601ProjectMS3;


IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DAT601ProjectMS3')
BEGIN
  CREATE DATABASE DAT601ProjectMS3;
END;
GO

USE DAT601ProjectMS3;
GO



CREATE PROCEDURE CreateDatabase
AS
 
	 
	CREATE TABLE Staff (
	  StaffID       int IDENTITY NOT NULL, 
	  GivenName     varchar(50) NOT NULL, 
	  LastName      varchar(50) NOT NULL, 
	  Email         varchar(100) NOT NULL, 
	  WorkPhone     varchar(20) NULL, 
	  PersonalPhone varchar(20) NOT NULL, 
	  Address       varchar(200) NOT NULL, 
	  Postcode      varchar(20) NOT NULL, 
	  CityID        int NOT NULL, 
	  PRIMARY KEY (StaffID));
	 
	 
	CREATE TABLE Supplier (
	  SupplierID int IDENTITY NOT NULL, 
	  CompanyName varchar(50) NOT NULL, 
	  PRIMARY KEY (SupplierID));
	 
	 
	CREATE TABLE Part (
	  PartID            int IDENTITY NOT NULL, 
	  PartNumber        varchar(25) NOT NULL, 
	  InstallationDate  datetime NOT NULL, 
	  ReplacementDate   datetime NULL, 
	  SupplierID        int NOT NULL, 
	  ReplacementPartID int NULL, 
	  SensorID          int NOT NULL, 
	  PRIMARY KEY (PartID));
	 
	 
	CREATE TABLE Sensor (
	  SensorID        int IDENTITY NOT NULL, 
	  ManafactureDate datetime NOT NULL, 
	  NextMaintenance date NOT NULL, 
	  LastMaintained  datetime NULL, 
	  MaintainerID    int NOT NULL, 
	  SensorType      varchar(25) NOT NULL, 
	  PRIMARY KEY (SensorID));
	 
	 
	CREATE TABLE SensorLocation (
	  SensorID  int NOT NULL, 
	  [Date]    datetime NOT NULL, 
	  Longitude decimal(9, 6) NOT NULL, 
	  Latitude decimal(8, 6) NOT NULL, 
	  Altitude  decimal(11, 1) NOT NULL, 
	  PRIMARY KEY (SensorID, 
	  [Date]));
	 
	 
	CREATE TABLE City (
	  CityID    int IDENTITY NOT NULL, 
	  CityName  varchar(100) NOT NULL, 
	  CountryID int NOT NULL, 
	  PRIMARY KEY (CityID));
	 
	 
	CREATE TABLE Country (
	  CountryID   int IDENTITY NOT NULL, 
	  CountryName varchar(100) NOT NULL, 
	  PRIMARY KEY (CountryID));
	 
	 
	CREATE TABLE Salesperson (
	  SalespersonID int IDENTITY NOT NULL, 
	  StaffID       int NOT NULL, 
	  PRIMARY KEY (SalespersonID));
	 
	 
	CREATE TABLE Executive (
	  ExecutiveID int IDENTITY NOT NULL, 
	  StaffID     int NOT NULL, 
	  PRIMARY KEY (ExecutiveID));
	 
	 
	CREATE TABLE Maintainer (
	  MaintainerID int IDENTITY NOT NULL, 
	  StaffID      int NOT NULL, 
	  PRIMARY KEY (MaintainerID));
	 
	 
	CREATE TABLE Audio (
	  AudioID   int IDENTITY NOT NULL, 
	  DataID    int NOT NULL, 
	  AudioFile image NOT NULL, 
	  PRIMARY KEY (AudioID, 
	  DataID));
	 
	 
	CREATE TABLE [3DImagery] (
	  ImageryID      int IDENTITY NOT NULL, 
	  DataID         int NOT NULL, 
	  SkeletalPoints image NULL, 
	  BodyShape      image NULL, 
	  Texture        image NULL, 
	  PRIMARY KEY (ImageryID, 
	  DataID));
	 
	 
	CREATE TABLE Data (
	  DataID       int IDENTITY NOT NULL, 
	  OwnerID      int NOT NULL, 
	  ZoneID       int NOT NULL, 
	  SensorID     int NOT NULL, 
	  CreationTime datetime NOT NULL, 
	  PRIMARY KEY (DataID));
	 
	 
	CREATE TABLE Zone (
	  ZoneID       int IDENTITY NOT NULL, 
	  CityID       int NOT NULL, 
	  Postcode     varchar(15) NOT NULL, 
	  LocationName varchar(100) NOT NULL, 
	  ContractID   int NOT NULL, 
	  PRIMARY KEY (ZoneID));
	 
	 
	CREATE TABLE ZoneSensor (
	  ZoneID        int NOT NULL, 
	  SensorID      int NOT NULL, 
	  PlacementDate datetime NOT NULL, 
	  PRIMARY KEY (ZoneID, 
	  SensorID));
	 
	 
	CREATE TABLE Contract (
	  ContractID    int IDENTITY NOT NULL, 
	  WrittenDate   date NOT NULL, 
	  EffectiveDate date NOT NULL, 
	  SensorID      int NOT NULL, 
	  SubscriberID  int NOT NULL, 
	  SalespersonID int NULL, 
	  ExecutiveID   int NOT NULL, 
	  PRIMARY KEY (ContractID));
	 
	 
	CREATE TABLE ContractSensor (
	  SensorID   int NOT NULL, 
	  ContractID int NOT NULL, 
	  PRIMARY KEY (SensorID, 
	  ContractID));
	 
	 
	CREATE TABLE Subscriber (
	  SubscriberID  int IDENTITY NOT NULL, 
	  GivenName     varchar(50) NOT NULL, 
	  LastName      varchar(50) NOT NULL, 
	  Email         varchar(100) NOT NULL, 
	  WorkPhone     varchar(20) NULL, 
	  PersonalPhone varchar(20) NOT NULL, 
	  Address       varchar(200) NOT NULL, 
	  Postcode      varchar(15) NOT NULL, 
	  CityID        int NOT NULL, 
	  PRIMARY KEY (SubscriberID));
	 
	 
	CREATE TABLE Subscription (
	  SubscriptionID     int IDENTITY NOT NULL, 
	  SubscriptionTypeID int NOT NULL, 
	  ContractID         int NOT NULL, 
	  SubscriptionStart  datetime NOT NULL, 
	  PRIMARY KEY (SubscriptionID));
	 
	 
	CREATE TABLE SubscriberType (
	  SubscriptionTypeID int IDENTITY NOT NULL, 
	  SubscriptionName   varchar(50) NOT NULL, 
	  PRIMARY KEY (SubscriptionTypeID));
	 
	 
	CREATE TABLE AccessLog (
	  SubscriptionID int NOT NULL, 
	  ActionID       int NOT NULL, 
	  DataID         int NOT NULL, 
	  TimePerformed  datetime NOT NULL, 
	  PRIMARY KEY (SubscriptionID, 
	  ActionID, 
	  DataID, 
	  TimePerformed));
	 
	 
	CREATE TABLE AccessAction (
	  ActionID   int IDENTITY NOT NULL, 
	  ActionName varchar(50) NOT NULL, 
	  PRIMARY KEY (ActionID));
	 
	 
	CREATE TABLE Video (
	  VideoID   int IDENTITY NOT NULL, 
	  DataID    int NOT NULL, 
	  VideoFile image NOT NULL, 
	  PRIMARY KEY (VideoID, 
	  DataID));
	 
	 
	ALTER TABLE Part ADD CONSTRAINT FKPart697498 FOREIGN KEY (SupplierID) REFERENCES Supplier (SupplierID);
	ALTER TABLE Part ADD CONSTRAINT FKPart179242 FOREIGN KEY (ReplacementPartID) REFERENCES Part (PartID);
	ALTER TABLE Part ADD CONSTRAINT FKPart916952 FOREIGN KEY (SensorID) REFERENCES Sensor (SensorID);
	
	ALTER TABLE City ADD CONSTRAINT FKCity890190 FOREIGN KEY (CountryID) REFERENCES Country (CountryID);
	
	ALTER TABLE Staff ADD CONSTRAINT FKStaff267992 FOREIGN KEY (CityID) REFERENCES City (CityID);
	
	ALTER TABLE Salesperson ADD CONSTRAINT FKSalesperso61998 FOREIGN KEY (StaffID) REFERENCES Staff (StaffID);
	
	ALTER TABLE Executive ADD CONSTRAINT FKExecutive390797 FOREIGN KEY (StaffID) REFERENCES Staff (StaffID);
	
	ALTER TABLE Maintainer ADD CONSTRAINT FKMaintainer217409 FOREIGN KEY (StaffID) REFERENCES Staff (StaffID);
	
	ALTER TABLE Sensor ADD CONSTRAINT FKSensor475026 FOREIGN KEY (MaintainerID) REFERENCES Maintainer (MaintainerID);
	 
	ALTER TABLE SensorLocation ADD CONSTRAINT FKSensorLoca211382 FOREIGN KEY (SensorID) REFERENCES Sensor (SensorID);
	
	ALTER TABLE Zone ADD CONSTRAINT FKZone681177 FOREIGN KEY (CityID) REFERENCES City (CityID);
	ALTER TABLE Zone ADD CONSTRAINT FKZone926800 FOREIGN KEY (ContractID) REFERENCES Contract (ContractID);
	
	ALTER TABLE ZoneSensor ADD CONSTRAINT FKZoneSensor399132 FOREIGN KEY (ZoneID) REFERENCES Zone (ZoneID);
	ALTER TABLE ZoneSensor ADD CONSTRAINT FKZoneSensor162467 FOREIGN KEY (SensorID) REFERENCES Sensor (SensorID);
	
	ALTER TABLE Contract ADD CONSTRAINT FKContract954545 FOREIGN KEY (ExecutiveID) REFERENCES Executive (ExecutiveID);
	ALTER TABLE Contract ADD CONSTRAINT FKContract359608 FOREIGN KEY (SalespersonID) REFERENCES Salesperson (SalespersonID);
	ALTER TABLE Contract ADD CONSTRAINT FKContract703015 FOREIGN KEY (SubscriberID) REFERENCES Subscriber (SubscriberID);
	
	ALTER TABLE ContractSensor ADD CONSTRAINT FKContractSe556880 FOREIGN KEY (SensorID) REFERENCES Sensor (SensorID);
	ALTER TABLE ContractSensor ADD CONSTRAINT FKContractSe255503 FOREIGN KEY (ContractID) REFERENCES Contract (ContractID);
	
	ALTER TABLE Subscriber ADD CONSTRAINT FKSubscriber223845 FOREIGN KEY (CityID) REFERENCES City (CityID);
	
	ALTER TABLE Subscription ADD CONSTRAINT FKSubscripti29916 FOREIGN KEY (SubscriptionTypeID) REFERENCES SubscriberType (SubscriptionTypeID);
	ALTER TABLE Subscription ADD CONSTRAINT FKSubscripti659448 FOREIGN KEY (ContractID) REFERENCES Contract (ContractID);
	
	ALTER TABLE Data ADD CONSTRAINT FKData451880 FOREIGN KEY (ZoneID, SensorID) REFERENCES ZoneSensor (ZoneID, SensorID);
	ALTER TABLE Data ADD CONSTRAINT FKData522920 FOREIGN KEY (OwnerID) REFERENCES Contract (ContractID);
	
	ALTER TABLE AccessLog ADD CONSTRAINT FKAccessLog31441 FOREIGN KEY (SubscriptionID) REFERENCES Subscription (SubscriptionID);
	ALTER TABLE AccessLog ADD CONSTRAINT FKAccessLog219796 FOREIGN KEY (ActionID) REFERENCES AccessAction (ActionID);
	ALTER TABLE AccessLog ADD CONSTRAINT FKAccessLog103568 FOREIGN KEY (DataID) REFERENCES Data (DataID);
	
	ALTER TABLE Video ADD CONSTRAINT FKVideo364307 FOREIGN KEY (DataID) REFERENCES Data (DataID);
	
	ALTER TABLE Audio ADD CONSTRAINT FKAudio400651 FOREIGN KEY (DataID) REFERENCES Data (DataID);
	
	ALTER TABLE [3DImagery] ADD CONSTRAINT FK3DImagery273197 FOREIGN KEY (DataID) REFERENCES Data (DataID);


GO

EXECUTE CreateDatabase;

USE master;
GO
