USE [VetClinic]
GO

/*************************************************************
**	<Procedure>
**	SpDeleteOwnerById
**
**	<Purpose>
**	Sets a owner to inactive
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	03/23/2020	TurtleMan	Initial Creation
*************************************************************/
CREATE OR ALTER PROCEDURE [dbo].[SpDeleteOwnerById](@OwnerId INT)
AS
BEGIN
	 UPDATE dbo.OwnerInfo
		SET IsActive = 0
	 WHERE OwnerId = @OwnerId AND
	 IsActive = 1
END;
GO


