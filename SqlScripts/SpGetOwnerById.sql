USE VetClinic
GO
/*************************************************************
**	<Procedure>
**	SpGetOwnerById
**
**	<Purpose>
**	Get A Owner by the owners Id
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	03/23/2020	TurtleMan	Initial Creation
*************************************************************/
CREATE OR ALTER PROCEDURE SpGetOwnerById( @OwnerId INT)
AS
 SELECT OwnerId,
		OwnerFirstName,
		OwnerLastName,
		OwnerAddress,
		OwnerCity,
		OwnerState,
		OwnerZip,
		OwnerPhone
FROM dbo.vVetClinicOwners
WHERE OwnerId = @OwnerId;

