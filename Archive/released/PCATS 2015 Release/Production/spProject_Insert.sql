ALTER PROCEDURE [dbo].[spProject_Insert]
@ID		int	output,
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
INSERT INTO
	DT_Projects
(
	[Number],
	[Description],
	[CustomerID],
	[CustomerProjNumber],
	[LocationID],
	[ProjMngrID],
	[RelationshipMngrID],
	[RateSchedID],
	[Multiplier],
	[Overlay],
	[Notes],
	[DateStart],
	[DateEnd],
	[IsProposal],
	[IsBooked],
	[IsActive],
	[IsGovernment],
	[IsMaster],
	[MasterID],
	[ReportingStatus],
	[POAmount],
	[LeadProjMngrID],
	[IsFixedRate]
)
VALUES
(
	@Number,
	@Description,
	@CustomerID,
	@CustomerProjNumber,
	@LocationID,
	@ProjMngrID,
	@RelationshipMngrID,
	@RateSchedID,
	@Multiplier,
	@Overlay,
	@Notes,
	@DateStart,
	@DateEnd,
	@IsProposal,
	@IsBooked,
	@IsActive,
	@IsGovernment,
	@IsMaster,
	@MasterID,
	@ReportingStatus,
	@POAmount,
	@LeadProjMngrID,
	@IsFixedRate

)


SELECT @ID = SCOPE_IDENTITY()

