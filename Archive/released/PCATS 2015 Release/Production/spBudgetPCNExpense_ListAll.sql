ALTER PROCEDURE [dbo].[spBudgetPCNExpense_ListAll]
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
