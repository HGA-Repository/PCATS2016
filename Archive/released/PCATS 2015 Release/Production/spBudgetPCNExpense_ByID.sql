ALTER PROCEDURE [dbo].[spBudgetPCNExpense_ByID]
@ID		int
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
	[DeptGroup] -- Added
FROM
	DT_BudgetPCNExpenses
WHERE
	[ID] = @ID
