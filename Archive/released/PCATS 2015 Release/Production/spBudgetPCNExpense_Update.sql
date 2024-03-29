ALTER PROCEDURE [dbo].[spBudgetPCNExpense_Update]
@ID		int,
@PCNID		int,
@Code		varchar(50),
@Description		varchar(200),
@DlrsPerItem		money,
@NumItems		int,
@MUPerc		money,
@MarkUp		money,
@TotalCost		money,
@DeptGroup int
AS
UPDATE
	DT_BudgetPCNExpenses
SET
	[PCNID] = @PCNID,
	[Code] = @Code,
	[Description] = @Description,
	[DlrsPerItem] = @DlrsPerItem,
	[NumItems] = @NumItems,
	[MUPerc] = @MUPerc,
	[MarkUp] = @MarkUp,
	[TotalCost] = @TotalCost,
	[DeptGroup] = @DeptGroup -- added 9/22/2015
WHERE
	[ID] = @ID
