ALTER PROCEDURE [dbo].[spEmployee_ListAll2]
AS
SELECT
	[ID],
	[Number],
	[Name],
	[Abbrev],
	[EmpTitleID],
	[MinHrs],
	[MaxRegHrs],
	[MaxAllHrs],
	[IsActive],
	[IsProjectManager],
	[IsRelManager], -- Added 7/13/15
	[Contractor],
	[OfficeLocation],
	[EngineerType]
FROM
	DT_Employees
WHERE
	[Deleted] = 0
ORDER BY
	[Name] ASC


