ALTER PROCEDURE [dbo].[spEmployee_ByID2]
@ID		int
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
	[IsRelManager],			-- Added 7/13/2015
	[Contractor],
	[OfficeLocation],
	[EngineerType]
	
	
FROM
	DT_Employees
WHERE
	[ID] = @ID


