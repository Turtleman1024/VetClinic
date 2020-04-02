
CREATE DATABASE VetClinic;
USE VetClinic;

CREATE TABLE OwnerInfo
(
	OwnerId        INT Identity(1,1) NOT NULL,
    OwnerFirstName VARCHAR(50)		 NOT NULL,
    OwnerLastName  VARCHAR(50)		 NOT NULL,
    OwnerAddress   VARCHAR(100)		 NOT NULL,
    OwnerCity      VARCHAR(50)		 NOT NULL,
    OwnerState     CHAR(2)			 NOT NULL,
    OwnerZip	   INT				 NOT NULL,
    OwnerPhone     VARCHAR(12)		 NOT NULL,
	IsActive	   BIT				 NOT NULL DEFAULT 1, 
    CONSTRAINT OwnerIdPK PRIMARY KEY(OwnerId)
);

CREATE TABLE PatientInfo
(
	PatientId        INT Identity(1,1) PRIMARY KEY NOT NULL,
    PatientName      VARCHAR(40)				   NOT NULL,
    PatientSpecies   VARCHAR(40)					   NOT NULL,
    PatientGender    CHAR(1) NOT NULL CHECK (PatientGender IN ('M', 'F')),
    PatientBirthDate DATE						   NOT NULL, /* YYYY-MM-DD */
    PatientNotes     VARCHAR(2500)				   NULL,
	IsActive		 BIT						   NOT NULL DEFAULT 1,
    OwnerId			 INT						   NULL,
    CONSTRAINT OwnerIdFK FOREIGN KEY(OwnerId) REFERENCES OwnerInfo(OwnerId) ON UPDATE CASCADE
);

/* Insert Owner Information*/
INSERT INTO OwnerInfo
(OwnerFirstName,OwnerlastName,OwnerAddress,OwnerCity,OwnerState,OwnerZip,OwnerPhone)
VALUES('Georgette','Smith','157 Pine Tree Lane','Richalnd','WA',99352,'555-568-7752');

INSERT INTO OwnerInfo
(OwnerFirstName,OwnerlastName,OwnerAddress,OwnerCity,OwnerState,OwnerZip,OwnerPhone)
VALUES('Jackson','Guiles','33 MacLaine Lane','Richalnd','WA',99352,'555-824-3351');

INSERT INTO OwnerInfo
(OwnerFirstName,OwnerlastName,OwnerAddress,OwnerCity,OwnerState,OwnerZip,OwnerPhone)
VALUES('Allison','Jones','99 Main Street','Richalnd','WA',99354,'555-336-8843');

/* Insert Patient Information */
INSERT INTO PatientInfo
(PatientName,PatientSpecies,PatientGender,PatientBirthDate,PatientNotes,OwnerId)
Values('Jacqueline of the March','Canine','F','2006-12-02','Golden Labrador',1);

INSERT INTO PatientInfo
(PatientName,PatientSpecies,PatientGender,PatientBirthDate,PatientNotes,OwnerId)
Values('Slick','Equine','M','2009-08-29','Hanoverian,Black',2);

INSERT INTO PatientInfo
(PatientName,PatientSpecies,PatientGender,PatientBirthDate,PatientNotes,OwnerId)
Values('Fluffy','Reptilia','F','2010-01-27','Banded Gila Monster',3);

INSERT INTO PatientInfo
(PatientName,PatientSpecies,PatientGender,PatientBirthDate,PatientNotes,OwnerId)
Values('Mr. Spiffy Pants','Feline','M','1997-05-22','Black & White,short hair, Manx',1);

