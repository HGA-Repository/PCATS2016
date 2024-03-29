ALTER PROCEDURE [dbo].[spBudgetPCNExpense_ListAllByPCN]
@PCNID	int
AS
SELECT
	[ID],
	[PCNID],
	[Code],
	[Description],
	[DlrsPerItem],
	[NumItems],
	[MUPerc],
	[MarkUp],
	[TotalCost],
	[DeptGroup] -- Added 9/22/2015
FROM
	DT_BudgetPCNExpenses
WHERE
	[Deleted] = 0
	AND
	[PCNID] = @PCNID
