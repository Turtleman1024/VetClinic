USE VetClinic 
GO

CREATE VIEW vVetClinicPatients
AS
 SELECT PatientId,
		PatientName,
		PatientSpecies,
		PatientGender,
		PatientBirthDate,
		PatientNotes,
		OwnerId
FROM dbo.PatientInfo;