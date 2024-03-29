ALTER PROCEDURE [dbo].[spProjectSummaryPCN_ListByProjectID1]
@ProjSumID	int,
@ProjectID	int
AS
SELECT
	[ID],
	0 as [ProjSumID],
	[ProjectID],
	[PCNNumber] as [Number],
	[DescofChange] as[Description],
	[EstimatedEngrHrs] as[Hours],
	[EstimatedEngrDlrs] as [Dollars],
	[Comments] as [Comments] -- Added 11/12
FROM
	DT_BudgetPCNS
WHERE
	[Deleted] = 0
	AND
	[PCNStatusID] = 1
	AND
	([EstimatedEngrHrs] <> '0' OR [EstimatedEngrDlrs] <> '0')
	AND
	--[ProjSumID] = @ProjSumID
	--AND
	[ProjectID] = @ProjectID
ORDER BY
	[PCNNumber] ASC

