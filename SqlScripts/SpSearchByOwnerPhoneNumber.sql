USE [VetClinic]
GO

/*************************************************************
**	<Procedure>
**	SpSearchByOwnerPhoneNumber
**
**	<Purpose>
**	Search for an owner by their phone number
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	11/24/2020	TurtleMan	Initial Creation
*************************************************************/
CREATE PROCEDURE [dbo].[SpSearchByOwnerPhoneNumber](@SearchValue VARCHAR(12))
AS
BEGIN
	 SELECT OwnerId,
			OwnerFirstName,
			OwnerLastName,
			OwnerPhone
	 FROM dbo.vVetClinicOwners
	 WHERE OwnerPhone LIKE '%' + @SearchValue + '%'
		   
END;
GO
