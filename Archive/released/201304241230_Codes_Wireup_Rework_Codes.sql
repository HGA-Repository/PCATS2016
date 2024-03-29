BEGIN TRANSACTION 

	DECLARE @now DATETIME
	SET @now = GETDATE()

	INSERT INTO SY_AccountCodeTasks
	SELECT 
		d.ID
		, ((a.code / 1000) * 1000) + 900 as [code] 
		, 'Rework', 0, @now, @now, null
	FROM SY_AccountCodeActivitys a 
	JOIN SY_AccountCodeDisciplines d on ((a.code / 1000) * 1000) = d.Code
	where a.code % 1000 = 999 and CategoryID is null and a.code > 10000
	
	
	INSERT INTO SY_AccountCodeCategorys
	SELECT 
		t.ID
		, ((a.code / 1000) * 1000) + 900 as [code] 
		, 'Rework', 0, @now, @now
	FROM SY_AccountCodeActivitys a 
	JOIN SY_AccountCodeTasks t on ((a.code / 1000) * 1000) + 900 = t.Code
	where a.code % 1000 = 999 and a.CategoryID is null and a.code > 10000
	
	UPDATE SY_AccountCodeActivitys
	set CategoryID = c.ID
	FROM SY_AccountCodeActivitys a
	join SY_AccountCodeCategorys c on ((a.code / 1000) * 1000) + 900 = c.Code
	where a.code % 1000 = 999 and a.CategoryID is null and a.code > 10000

COMMIT

