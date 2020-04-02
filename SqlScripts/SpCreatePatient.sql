USE VetClinic
GO
/*************************************************************
**	<Procedure>
**	SpCreatePatient
**
**	<Purpose>
**	Creates a new patient
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	04/02/2020	TurtleMan	Initial Creation
*************************************************************/
CREATE OR ALTER PROCEDURE SpCreatePatient(@PatientName VARCHAR(40),
										  @PatientSpecies VARCHAR(40),
										  @PatientGender CHAR(1),
										  @PatientBirthDate DATETIME2,
										  @PatientNotes VARCHAR(2500),
										  @OwnerId INT,
										  @PatientId INT OUTPUT)
AS
BEGIN
	 INSERT INTO dbo.PatientInfo 
		   (PatientName,
			PatientSpecies,
			PatientGender,
			PatientBirthDate,
			PatientNotes,
			OwnerId)
	VALUES(@PatientName,
		   @PatientSpecies,
		   @PatientGender,
		   @PatientBirthDate,
		   @PatientNotes,
		   @OwnerId);
	
	SET @PatientId = SCOPE_IDENTITY();
END;