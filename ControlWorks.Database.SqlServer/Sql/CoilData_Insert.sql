USE [CoilInfo]
GO


CREATE OR ALTER PROCEDURE [dbo].[CoilData_Insert]
(
	@materialType nvarchar(30),
	@materialThickness decimal(9,5),
	@originalSqYards int,
	@batchNumber nvarchar(30),
	@changeNumber nvarchar(30),
	@extrusionDate smalldatetime,
	@rollSnNumber nvarchar(30),
	@coilNumber smallint,
	@coilWidth decimal(9,5),
	@tolerancePlus decimal(9,5),
	@toleranceMinus decimal(9,5),
	@inspector nvarchar(30),
	@inspectionDateTime smalldatetime,
	@calibrationDate smalldatetime,
	@generatedMaterialType nvarchar(40),
	@ovenPos int,
	@batchRunTimestamp smalldatetime,
	@machineNumber int,
	@coilSnNumber nvarchar(30),
	@labInspector nvarchar(30),
	@rollNumber int,
	@labInspectDate smalldatetime,
	@ipAddress varchar(50),
	@cpuName varchar(50)
)
AS 
BEGIN
 INSERT INTO [dbo].[CoilData] 
 (
	  [MaterialType] 
	 ,[MaterialThickness] 
	 ,[OriginalSqYards] 
	 ,[BatchNumber] 
	 ,[ChangeNumber] 
	 ,[ExtrusionDate] 
	 ,[RollSnNumber] 
	 ,[CoilNumber] 
	 ,[CoilWidth] 
	 ,[TolerancePlus] 
	 ,[ToleranceMinus] 
	 ,[Inspector] 
	 ,[InspectionDateTime] 
	 ,[CalibrationDate] 
	 ,[GeneratedMaterialType] 
	 ,[OvenPos] 
	 ,[BatchRunTimestamp] 
	 ,[MachineNumber] 
	 ,[CoilSnNumber] 
	 ,[LabInspector] 
	 ,[RollNumber] 
	 ,[LabInspectDate] 
	 ,[IpAddress] 
	 ,[CpuName]) 
 VALUES 
 ( 
	  @materialType 
	 ,@materialThickness 
	 ,@originalSqYards 
	 ,@batchNumber 
	 ,@changeNumber 
	 ,@extrusionDate 
	 ,@rollSnNumber 
	 ,@coilNumber 
	 ,@coilWidth 
	 ,@tolerancePlus 
	 ,@toleranceMinus 
	 ,@inspector 
	 ,@inspectionDateTime 
	 ,@calibrationDate 
	 ,@generatedMaterialType 
	 ,@ovenPos 
	 ,@batchRunTimestamp 
	 ,@machineNumber 
	 ,@coilSnNumber 
	 ,@labInspector 
	 ,@rollNumber 
	 ,@labInspectDate 
	 ,@ipAddress 
	 ,@cpuName 
 )

END
