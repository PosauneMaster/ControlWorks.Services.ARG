USE [CoilInfo]
GO

CREATE OR ALTER PROCEDURE [dbo].[SensorData_Insert]
(
     @coilDataId int
    ,@sensorNumber smallint
    ,@position decimal(9,5)
    ,@sensorData0 decimal(9,5)
    ,@sensorData1 decimal(9,5)
    ,@sensorData2 decimal(9,5)
    ,@sensorData3 decimal(9,5)
    ,@sensorData4 decimal(9,5)
)
AS
INSERT INTO [dbo].[SensorData]
    ([CoilDataId]
    ,[SensorNumber]
    ,[Position]
    ,[SensorData0]
    ,[SensorData1]
    ,[SensorData2]
    ,[SensorData3]
    ,[SensorData4])
VALUES
(
     @coilDataId
    ,@sensorNumber
    ,@position
    ,@sensorData0
    ,@sensorData1
    ,@sensorData2
    ,@sensorData3
    ,@sensorData4
)
GO