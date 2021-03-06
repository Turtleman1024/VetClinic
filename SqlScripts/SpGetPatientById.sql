USE [VetClinic]
GO
/****** Object:  StoredProcedure [dbo].[SpGetOwnerById]    Script Date: 3/31/2020 2:49:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*************************************************************
**	<Procedure>
**	SpGetPatientById
**
**	<Purpose>
**	Get a Patient by the patient Id
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	03/31/2020	TurtleMan	Initial Creation
*************************************************************/
CREATE OR ALTER PROCEDURE [dbo].[SpGetPatientById](@PatientId INT)
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
WHERE PatientId = @PatientId

