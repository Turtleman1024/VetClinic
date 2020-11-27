USE [VetClinic]
GO

/*************************************************************
**	<Procedure>
**	SpSearchForOwner
**
**	<Purpose>
**	Search for a owner
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	11/26/2020	TurtleMan	Initial Creation
*************************************************************/
CREATE PROCEDURE [dbo].[SpSearchForOwner](@SearchValue VARCHAR(40))
AS
BEGIN
	 SELECT OwnerId,
			OwnerFirstName,
			OwnerLastName,
			OwnerAddress,
			OwnerCity,
			OwnerState,
			OwnerPhone
	 FROM dbo.vVetClinicOwners
	 WHERE OwnerFirstName LIKE '%' + UPPER(@SearchValue) + '%' OR
		   OwnerLastName LIKE '%' + UPPER(@SearchValue) + '%' OR
		   OwnerPhone LIKE '%' + UPPER(@SearchValue) + '%'
END;
GO
