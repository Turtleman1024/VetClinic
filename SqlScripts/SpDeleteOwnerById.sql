USE [VetClinic]
GO

/*************************************************************
**	<Procedure>
**	SpDeleteOwnerById
**
**	<Purpose>
**  We never delete a Owner we only set them and thier pets to inactive
**  This way we keep records for future reporting or if the owner 
**	becomes a client again
**	
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
	 IsActive = 1;

	 UPDATE dbo.PatientInfo
		SET IsActive = 0
		WHERE OwnerId = @OwnerId;
END;
GO


