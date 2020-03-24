USE VetClinic
GO

CREATE VIEW vVetClinicOwners
AS
 SELECT OwnerId,
		OwnerFirstName,
		OwnerLastName,
		OwnerAddress,
		OwnerCity,
		OwnerState,
		OwnerZip,
		OwnerPhone
FROM dbo.OwnerInfo;