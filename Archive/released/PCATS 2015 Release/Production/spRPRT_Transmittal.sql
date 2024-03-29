ALTER PROCEDURE [dbo].[spRPRT_Transmittal]
@TransmittalID	int
AS
SELECT
	t.[TransmittalNumber]
	,t.[ProjectClient]
	,t.[DateTransmittal]
	,t.[ProjectTitle]
	,t.[TransmittalTo]
	,t.[WeTransmitHereWith]
	,t.[UnderSeperateCover]
	,t.[SentDrawings]
	,t.[SentSpecifications]
	,t.[SentSchedule]
	,t.[SentBrochure]
	,t.[SentCorrespondence]
	,t.[ForPreliminary]
	,t.[ForApproval]
	,t.[ForBidding]
	,t.[ForConstruction]
	,t.[ForNoted]
	,t.[ForNotedOther]
	,t.[ByUSPS]
	,t.[ByEmail]
	,t.[ByOvernight]
	,t.[BySecondDay]
	,t.[ByMessenger]
	,t.[GeneralDesc]
	,t.[Comments]
	,t.[PC]
	,t.[ReleasedBy]
	,t.[SentBy]
	,td.[Copies]
	,td.[DocDwgNo]
	,td.[Revision]
	,td.[DateTrans]
	,td.[Description]
FROM
	dt_Transmittals t
	LEFT JOIN
	dt_TransmittalDocs td ON t.[ID] = td.[TransmittalID]
WHERE
	t.[ID] = @TransmittalID
	AND
	td.[Deleted] = 0
ORDER BY
	td.[DocDwgNo] ASC

-- Counts No of Documents -- Added 9/28/2015
SELECT COUNT(*) as no_of_Doc FROM dt_TransmittalDocs
WHERE
	[TransmittalID] = @TransmittalID
	AND
	[Deleted] = 0

