USE [VetClinic]
GO

/*************************************************************
**	<Procedure>
**	SpGetOwners
**
**	<Purpose>
**	Get all active Owners
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	03/23/2020	TurtleMan	Initial Creation
*************************************************************/
CREATE OR ALTER PROCEDURE [dbo].[SpGetOwners]
AS
 SELECT OwnerId,
		OwnerFirstName,
		OwnerLastName,
		OwnerAddress,
		OwnerCity,
		OwnerState,
		OwnerZip,
		OwnerPhone,
		IsActive
FROM dbo.vVetClinicOwners
GO


