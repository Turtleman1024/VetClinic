USE [VetClinic]
GO
/*************************************************************
**	<Procedure>
**	SpGetPatientssByLastName
**
**	<Purpose>
**	Get Patients by the patient's name
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	04/06/2020	TurtleMan	Initial Creation
*************************************************************/
CREATE OR ALTER PROCEDURE [dbo].[SpGetPatientsName]( @PatientName VARCHAR(40))
AS
 SELECT PatientId,
		PatientName,
		PatientSpecies,
		PatientGender,
		PatientBirthDate,
		PatientNotes,
		IsActive,
		OwnerId
FROM dbo.vVetClinicPatients
WHERE PatientName LIKE @PatientName + '%';

