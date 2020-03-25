USE VetClinic
GO
/*************************************************************
**	<Procedure>
**	SpCreateOwner
**
**	<Purpose>
**	Creates a new owner
**
**	<History>
**	<Date>		<Author>	<Reasoning>
**	03/23/2020	TurtleMan	Initial Creation
*************************************************************/
CREATE OR ALTER PROCEDURE SpCreateOwner(@OwnerFirstName VARCHAR(50),
										@OwnerLastName VARCHAR(50),
										@OwnerAddress VARCHAR(100),
										@OwnerCity VARCHAR(50),
										@OwnerState CHAR(2),
										@OwnerZip INT,
										@OwnerPhone VARCHAR(12),
										@OwnerId INT OUTPUT)
AS
BEGIN
	 INSERT INTO dbo.OwnerInfo 
		   (OwnerFirstName,
			OwnerLastName,
			OwnerAddress,
			OwnerCity,
			OwnerState,
			OwnerZip,
			OwnerPhone)
	VALUES(@OwnerFirstName,
		   @OwnerLastName,
		   @OwnerAddress,
		   @OwnerCity,
		   @OwnerState,
		   @OwnerZip,
		   @OwnerPhone);
	
	SET @OwnerId = SCOPE_IDENTITY();
END;