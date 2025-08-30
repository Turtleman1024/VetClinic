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
**  08/29/2025  TurtleMan	Return affected owner rows.
*************************************************************/
CREATE OR ALTER PROCEDURE [dbo].[SpDeleteOwnerById](@OwnerId INT)
AS
BEGIN
	 UPDATE dbo.OwnerInfo
		SET IsActive = 0
	 WHERE OwnerId = @OwnerId AND
	 IsActive = 1;
	 
	 -- Return affected rows for owner update	 
	 SELECT @@ROWCOUNT AS OwnerRowsAffected;

	 UPDATE dbo.PatientInfo
		SET IsActive = 0
		WHERE OwnerId = @OwnerId;
END;
GO


