USE [VetClinic]
GO

/*************************************************************
**	<Procedure>
**	SpDeletePatientById
**
**	<Purpose>
**	Delete Patient by id
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	02/09/2021	TurtleMan	Initial Creation
*************************************************************/
CREATE OR ALTER PROCEDURE [dbo].[SpDeletePatientById](@PatientId INT)
AS
BEGIN
	 DELETE FROM dbo.PatientInfo
	 WHERE PatientId = @PatientId;

	 SELECT PatientId FROM dbo.PatientInfo 
	 WHERE PatientId = @PatientId;
END;
GO


