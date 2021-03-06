USE [VetClinic]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*************************************************************
**	<Procedure>
**	SpUpdateOwner
**
**	<Purpose>
**	Updates the information of a owner
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	03/25/2020	TurtleMan	Initial Creation
*************************************************************/
CREATE OR ALTER PROCEDURE [dbo].[SpUpdateOwner](@OwnerId INT,
									   @OwnerFirstName VARCHAR(50),
									   @OwnerLastName VARCHAR(50),
									   @OwnerAddress VARCHAR(100),
									   @OwnerCity VARCHAR(50),
									   @OwnerState CHAR(2),
									   @OwnerZip INT,
									   @OwnerPhone VARCHAR(12))
AS
BEGIN
	UPDATE dbo.OwnerInfo
		SET OwnerFirstName = @OwnerFirstName,
			OwnerLastName = @OwnerLastName,
			OwnerAddress = @OwnerAddress,
			OwnerCity = @OwnerCity,
			OwnerState = @OwnerState,
			OwnerZip = @OwnerZip,
			OwnerPhone = @OwnerPhone
	WHERE OwnerId = @OwnerId;
END;