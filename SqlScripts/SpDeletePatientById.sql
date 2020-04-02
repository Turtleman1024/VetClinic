USE [VetClinic]
GO

/*************************************************************
**	<Procedure>
**	SpDeletePatientById
**
**	<Purpose>
**	Sets a patient to inactive
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	04/02/2020	TurtleMan	Initial Creation
*************************************************************/
CREATE OR ALTER PROCEDURE [dbo].[SpDeletePatientById](@PatientId INT)
AS
BEGIN
	 UPDATE dbo.PatientInfo
		SET IsActive = 0
	 WHERE PatientId = @PatientId AND
	 IsActive = 1
END;
GO


