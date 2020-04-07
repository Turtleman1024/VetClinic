USE [VetClinic]
GO

/*************************************************************
**	<Procedure>
**	SpGetOwnersByLastName
**
**	<Purpose>
**	Get A Owner by the owners last name
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	04/05/2020	TurtleMan	Initial Creation
*************************************************************/
CREATE OR ALTER PROCEDURE [dbo].[SpGetOwnersByLastName]( @OwnersLastName VARCHAR(50))
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
WHERE OwnerLastName LIKE @OwnersLastName + '%';

