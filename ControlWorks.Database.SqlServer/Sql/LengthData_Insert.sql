USE [CoilInfo]
GO

CREATE OR ALTER PROCEDURE [dbo].[LengthData_Insert]
(
	 @coilDataId int
	,@good decimal(9,5)
	,@thicknessScrap decimal(9,5)
	,@thicknessReclass decimal(9,5)
	,@blisters decimal(9,5)
	,@contamination decimal(9,5)
	,@gas decimal(9,5)
	,@holes decimal(9,5)
	,@lumps decimal(9,5)
	,@paperBreaks decimal(9,5)
	,@paperSplice decimal(9,5)
	,@shiny decimal(9,5)
	,@slitterDefect decimal(9,5)
	,@tapeInCoil decimal(9,5)
	,@wrinkles decimal(9,5)
	,@width decimal(9,5)
	,@other decimal(9,5)
	,@salvage decimal(9,5)
	,@linearMeters decimal(9,5)
)
AS

INSERT INTO [dbo].[LengthData]
           ([CoilDataId]
           ,[Good]
           ,[ThicknessScrap]
           ,[ThicknessReclass]
           ,[Blisters]
           ,[Contamination]
           ,[Gas]
           ,[Holes]
           ,[Lumps]
           ,[PaperBreaks]
           ,[PaperSplice]
           ,[Shiny]
           ,[SlitterDefect]
           ,[TapeInCoil]
           ,[Wrinkles]
           ,[Width]
           ,[Other]
           ,[Salvage]
           ,[LinearMeters])
     VALUES
	 (
		 @coilDataId
		,@good
		,@thicknessScrap
		,@thicknessReclass
		,@blisters
		,@contamination
		,@gas
		,@holes
		,@lumps
		,@paperBreaks
		,@paperSplice
		,@shiny
		,@slitterDefect
		,@tapeInCoil
		,@wrinkles
		,@width
		,@other
		,@salvage
		,@linearMeters
	)
GO