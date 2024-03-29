/*

SELECT * FROM SY_UnitOfMeasures
SELECT *  FROM [SY_ExpenseAccounts] where Code = 'E150'

*/

BEGIN TRANSACTION


	UPDATE [SY_ExpenseAccounts] set UOMID = 3, DefaultRate= 0.565, DefaultMU=10.00 where Code = 'E150'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 550.00, DefaultMU=10.00 where Code = 'E510'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 850.00, DefaultMU=10.00 where Code = 'E521'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 850.00, DefaultMU=10.00 where Code = 'E521'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 95.00, DefaultMU=10.00 where Code = 'E522'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 250.00, DefaultMU=10.00 where Code = 'E523'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 55.00, DefaultMU=10.00 where Code = 'E541'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 85.00, DefaultMU=10.00 where Code = 'E542'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 35.00, DefaultMU=10.00 where Code = 'E543'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 10.00, DefaultMU=10.00 where Code = 'E551'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 10.00, DefaultMU=10.00 where Code = 'E561'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 6.00, DefaultMU=10.00 where Code = 'E562'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 15.00, DefaultMU=10.00 where Code = 'E580'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 460.00, DefaultMU=10.00 where Code = 'E591'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 270.00, DefaultMU=10.00 where Code = 'E592'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 175.00, DefaultMU=10.00 where Code = 'E593'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 225.00, DefaultMU=10.00 where Code = 'E594'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 45.00, DefaultMU=10.00 where Code = 'E595'
	UPDATE [SY_ExpenseAccounts] set UOMID = 2, DefaultRate= 175.00, DefaultMU=10.00 where Code = 'E596'
	
	
	
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 15.00, DefaultMU=10.00 where Code = 'E601'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 100.00,DefaultMU=10.00 where Code = 'E602'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 50.00, DefaultMU=10.00 where Code = 'E603'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 35.00, DefaultMU=10.00 where Code = 'E604'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 75.00, DefaultMU=10.00 where Code = 'E605'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 20.00, DefaultMU=10.00 where Code = 'E606'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 20.00, DefaultMU=10.00 where Code = 'E607'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 25.00, DefaultMU=10.00 where Code = 'E608'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 60.00, DefaultMU=10.00 where Code = 'E609'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 75.00, DefaultMU=10.00 where Code = 'E610'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 20.00, DefaultMU=10.00 where Code = 'E611'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 10.00, DefaultMU=10.00 where Code = 'E612'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 5.00,  DefaultMU=10.00 where Code = 'E613'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 15.00, DefaultMU=10.00 where Code = 'E614'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 15.00, DefaultMU=10.00 where Code = 'E615'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 20.00, DefaultMU=10.00 where Code = 'E616'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 10.00, DefaultMU=10.00 where Code = 'E617'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 25.00, DefaultMU=10.00 where Code = 'E618'
	UPDATE [SY_ExpenseAccounts] set UOMID = 9, DefaultRate= 10.00, DefaultMU=10.00 where Code = 'E619'
	

	
	
	
	
	
	DELETE DT_BudgetExpenseLines where Quantity = 0 and TotalDollars = 0
	
	
COMMIT

