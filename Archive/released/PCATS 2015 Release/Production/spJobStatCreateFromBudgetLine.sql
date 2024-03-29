ALTER PROCEDURE [dbo].[spJobStatCreateFromBudgetLine]
@ID int
,@BudgetID int
,@DeptGroup int
,@Activity int
,@Description varchar(200)
,@Quantity int
,@HoursEach int
,@LineGUID uniqueidentifier

AS

DECLARE @lineExist int
DECLARE @counter int
DECLARE @deptid int
DECLARE @projid int
DECLARE @projleadid int
DECLARE @actcodeid int
Declare @IsTask int		-- Added 9/30/2015

SELECT @projid = [ProjectID] FROM DT_Budgets WHERE [ID] = @BudgetID
SELECT @projleadid = [ProjMngrID] FROM DT_Projects WHERE [ID] = @projid
SELECT @actcodeid = ISNULL([ID],0) FROM DT_ActivityCodes WHERE [Code] = CAST(@Activity AS money)
SELECT @deptid = [ID] FROM DT_Departments WHERE [AcctGroup] = @DeptGroup AND [Deleted] = 0
SELECT @lineExist = COUNT(*) FROM DT_DrawingLogs WHERE [BudgetLineGUID] = @LineGUID


-- Set IsTask = 1, for deptid = 10
if @deptid = 10
	begin
		set @IsTask = 1
	end
else
begin 
	set @IsTask = 0
end

-- SET @lineExist = 0		-- turn off to force update all

IF @lineExist < 1
BEGIN

SET @counter = 0

WHILE @counter < @Quantity
BEGIN

SET @counter = @counter + 1

INSERT INTO DT_DrawingLogs
           ([DepartmentID]
           ,[ProjectID]
           ,[ProjectLeadID]
           ,[HGANumber]
           ,[ClientNumber]
           ,[CADNumber]
           ,[ActCodeID]
           ,[IsTask]
           ,[DrawingSizeID]
           ,[BudgetHrs]
           ,[PercentComplete]
           ,[RemainingHrs]
           ,[EarnedHrs]
           ,[Title1]
           ,[Title1IsTitle]
           ,[Title1IsDesc]
			,[BudgetLineGUID])
     VALUES
           (@deptid
           ,@projid
           ,@projleadid
           ,CAST(@Activity AS varchar(4)) + '-' + CAST(@counter AS varchar(2))
           ,''
           ,''
           ,@actcodeid
           --,0 updated 9/30/2015
		   ,@IsTask
           ,4
           ,@HoursEach
           ,0
           ,@HoursEach
           ,0
           ,LEFT(@Description, 100)
           ,1
           ,1
			,@LineGUID)

END

END

