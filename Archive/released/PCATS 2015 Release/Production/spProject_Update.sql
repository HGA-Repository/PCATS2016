ALTER PROCEDURE [dbo].[spProject_Update]
@ID		int,
@Number		varchar(50),
@Description		varchar(100),
@CustomerID		int,
@CustomerProjNumber varchar(50),
@LocationID		int,
@ProjMngrID		int,
@RelationshipMngrID int,
@RateSchedID	int,
@Multiplier		money,
@Overlay		money,
@Notes		text,
@DateStart		smalldatetime,
@DateEnd		smalldatetime,
@IsProposal	bit,
@IsBooked	bit,
@IsActive	bit,
@IsGovernment	bit,
@IsMaster	bit,
@MasterID	int,
@ReportingStatus int,
@POAmount	varchar(50),
@LeadProjMngrID	int,
@IsFixedRate	bit -- Added
AS
UPDATE
	DT_Projects
SET
	[Number] = @Number,
	[Description] = @Description,
	[CustomerID] = @CustomerID,
	[CustomerProjNumber] = @CustomerProjNumber,
	[LocationID] = @LocationID,
	[ProjMngrID] = @ProjMngrID,
	[RelationshipMngrID] = @RelationshipMngrID,
	[RateSchedID] = @RateSchedID,
	[Multiplier] = @Multiplier,
	[Overlay] = @Overlay,
	[Notes] = @Notes,
	[DateStart] = @DateStart,
	[DateEnd] = @DateEnd,
	[IsProposal] = @IsProposal,
	[IsBooked] = @IsBooked,
	[IsActive] = @IsActive,
	[IsGovernment] = @IsGovernment,
	[IsMaster] = @IsMaster,
	[MasterID] = @MasterID,
	[ReportingStatus] = @ReportingStatus,
	[POAmount] = @POAmount,
	[LeadProjMngrID] = @LeadProjMngrID,
	[IsFixedRate] = @IsFixedRate
WHERE
	[ID] = @ID


-- update the select list to not include this project
if @IsActive = 0
BEGIN
	UPDATE
		DT_CostReportBatchLists
	SET
		[PrintList] = @IsActive
END

