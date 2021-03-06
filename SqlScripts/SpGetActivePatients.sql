USE [VetClinic]
GO
/****** Object:  StoredProcedure [dbo].[SpGetOwners]    Script Date: 3/31/2020 2:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*************************************************************
**	<Procedure>
**	SpGetActivePatients
**
**	<Purpose>
**	Get all Active Patients
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	4/13/2020	TurtleMan	Initial Creation
*************************************************************/
CREATE OR ALTER PROCEDURE [dbo].[SpGetActivePatients]
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
WHERE IsActive = 1;