USE [VetClinic]
GO

/*************************************************************
**	<Procedure>
**	SpUpdatePatient
**
**	<Purpose>
**	Updates the information of a patient
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	04/02/2020	TurtleMan	Initial Creation
**  12/04/2020  Turtleman	Adding IsActive
*************************************************************/
CREATE OR ALTER PROCEDURE [dbo].[SpUpdatePatient](@IsActive BIT,
										  @PatientId INT,
										  @PatientName VARCHAR(40),
										  @PatientSpecies VARCHAR(40),
										  @PatientGender CHAR(1),
										  @PatientBirthDate DATETIME2,
										  @PatientNotes VARCHAR(2500),
										  @OwnerId INT)
AS
BEGIN
	UPDATE dbo.PatientInfo
		SET IsActive = @IsActive,
			PatientName = @PatientName,
			PatientSpecies = @PatientSpecies,
			PatientGender = @PatientGender,
			PatientBirthDate = @PatientBirthDate,
			PatientNotes = @PatientNotes
	WHERE OwnerId = @OwnerId AND
		  PatientId = @PatientId;
END;
GO