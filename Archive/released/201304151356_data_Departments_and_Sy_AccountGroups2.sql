BEGIN TRANSACTION

	DECLARE @now DATETIME 
	SET @now = GETDATE()

	DELETE FROM DT_Departments where Deleted = 1
	
	
	INSERT INTO DT_Departments
	SELECT '', 'Inst', 'Instrumentation', 16000, 6, 1, 0 ,@now, @now
	
	INSERT INTO DT_Departments
	SELECT '', 'Sur', 'Surveying', 19000, 0, 1, 0 ,@now, @now
	
	INSERT INTO DT_Departments
	SELECT '', 'ROW', 'Right of Way/Permitting', 20000, 0, 1, 0 ,@now, @now
	
	INSERT INTO DT_Departments
	SELECT '', 'CMI', 'Construction Management/Inspection', 21000, 0, 1, 0 ,@now, @now
		
	INSERT INTO DT_Departments
	SELECT '', 'E&P', 'Environmental & Permitting', 22000, 0, 1, 0 ,@now, @now
	
	UPDATE DT_Departments set Number = ''
	
	UPDATE DT_Departments set Description = 'Electrical' where ID = 13
	UPDATE DT_Departments set Name = 'Elec' where ID = 13
	


	
	
	DELETE FROM SY_AccountGroups2 where AcctNumber is null
	SELECT * into #temp from SY_AccountGroups2
	
	TRUNCATE table SY_AccountGroups2
	
	INSERT INTO SY_AccountGroups2
	SELECT code,Description,-1,null,null,null,null,1,0,1,1,0 FROM SY_AccountCodeDisciplines
	where code > 1000
	
	INSERT INTO SY_AccountGroups2
	SELECT code,Description,-1,null,null,null,null,1,0,1,1,0 
	FROM SY_AccountCodeTasks where code < 1000 and code > 0
	
	UPDATE SY_AccountGroups2
	SET StartOld = o.StartOld
	, EndOld = o.EndOld
	from SY_AccountGroups2 n
	join #temp o on n.AcctNumber = o.AcctNumber
	
	UPDATE SY_AccountGroups2 set StartNew = AcctNumber
	UPDATE SY_AccountGroups2 set EndNew = AcctNumber + 999 where AcctNumber > 1000
	UPDATE SY_AccountGroups2 set EndNew = AcctNumber + 99 where AcctNumber < 1000
	
	UPDATE SY_AccountGroups2
	set DepartmentID = d.ID 
	FROM  SY_AccountGroups2 g
	join DT_Departments d on d.AcctGroup =g.AcctNumber

	--SELECT * FROM SY_AccountGroups2
	--SELECT * FROM #temp
	
	DROP TABLE #temp


COMMIT

