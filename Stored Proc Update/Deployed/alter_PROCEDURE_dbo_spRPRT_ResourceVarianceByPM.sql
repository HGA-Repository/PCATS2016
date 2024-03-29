USE [RSManpowerSchDb]
GO
/****** Object:  StoredProcedure [dbo].[spRPRT_ResourceVarianceByPM]    Script Date: 3/22/2016 11:18:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spRPRT_ResourceVarianceByPM]
@ProjMngrID  int
AS

SELECT
	pm.Name AS [SortVal]
	,pm.Name AS [DeptGroup]
	,fms.[ProjectType] AS [Indust]
	,proj.Number AS [ProjNumber]
	,proj.Description AS [ProjTitle]
	,cust.Name AS [Customer]
	--,ROUND(ps.JSRmn,0) AS JSRmn
	,ROUND(ps.MPRmn,0) AS JSRmn
	,ROUND(ps.MPRmn,0) AS MPRmn
	,ROUND(ps.budTot,0) AS budTot
	,ROUND(ps.ForToCmp,0) AS ForToCmp
	,w.EndOfWeek
FROM
	(
	SELECT
		ps.ProjID
		,SUM(ps.budTot) AS [budTot]
		,SUM(ps.JSRmn) AS [JSRmn]
		,SUM(ps.MPRmn) AS [MPRmn]
		,SUM(ps.ForToCmp) AS [ForToCmp]
	FROM
		vwProjectStatusByDept ps
	GROUP BY
		ps.ProjID
	) ps
	LEFT JOIN
	DT_Projects proj ON ps.ProjID = proj.ID
	LEFT JOIN
	DT_Employees pm ON proj.ProjMngrID = pm.ID
	LEFT JOIN
	DT_Customers cust ON proj.CustomerID = cust.ID
	LEFT JOIN
	(
	SELECT
		0 AS [ProjAdd]
		,[EndOfWeek]
	FROM
		SY_WeekLists 
	WHERE
		GETDATE() BETWEEN [StartOfWeek] AND [EndOfWeek]
	) w ON ps.[ProjID] > w.[ProjAdd]
	LEFT JOIN
	dt_FMSProjectData fms ON proj.[Number] = fms.[cproject]
WHERE
	ps.JSRmn + ps.MPRmn + ps.budTot + ps.ForToCmp > 0
	AND
	pm.ID = @ProjMngrID
	AND
	CHARINDEX('X',proj.Number) < 1
	AND
	proj.[Deleted] = 0
ORDER BY
	proj.Number ASC
