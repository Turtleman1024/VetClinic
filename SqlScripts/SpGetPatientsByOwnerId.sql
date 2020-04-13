USE VetClinic
GO
/*************************************************************
**	<Procedure>
**	SpGetPatientsByOwnerId
**
**	<Purpose>
**	Get Patients by Owners Id
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	03/23/2020	TurtleMan	Initial Creation
*************************************************************/
CREATE OR ALTER PROCEDURE SpGetPatientsByOwnerId (@OwnerId INT )
AS
 SELECT PatientId,
		PatientName,
		PatientSpecies,
		PatientGender,
		PatientBirthDate,
		PatientNotes,
		OwnerId,
		IsActive
FROM dbo.vVetClinicPatients
WHERE OwnerId = @OwnerId;