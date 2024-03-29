BEGIN TRANSACTION

	DECLARE @now DATETIME 
	set @now = GETDATE()

	INSERT INTO [DT_ActivityCodes]
	SELECT 
	al.code
	, al.Description
	, NULL
	, case when al.code % 10000 = 0 then 1 else 0 end
	, 0
	,@now ,@now
	FROM vwAllAccountCodes al
	left join [DT_ActivityCodes] ac on al.code = ac.Code
	where ac.Code is null and al.code >= 10000 and al.Description <> 'Future Use'
	

	UPDATE [DT_ActivityCodes]
	set TotalOn = case when p.ID = ac.ID then gp.ID else ISNULL(p.ID, gp.ID) END
	FROM [DT_ActivityCodes] ac
	left join vwCodeTasks t on t.code = ac.Code
	left join vwCodeGroups g on g.code = ac.Code
	LEFT JOIN (select * from [DT_ActivityCodes]) p on p.Code = t.TaskCode
	LEFT JOIN (select * from [DT_ActivityCodes]) gp on gp.Code = g.CodeGroup 
	WHERE ac.TotalOn is null
	
	


COMMIT


