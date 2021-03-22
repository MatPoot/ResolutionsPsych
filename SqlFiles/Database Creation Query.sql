

--***DROP TABLES***

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'Appointments'
)
DROP TABLE Appointments

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'Clients'
)
DROP TABLE Clients

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'Counsellors'
)
DROP TABLE Counsellors

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'Logins'
)
DROP TABLE Logins
--***END DROP TABLES***

CREATE TABLE Clients
(
	ClientID INT IDENTITY (1, 1) NOT NULL,
	FirstName VARCHAR(10) NOT NULL,
	MiddleName VARCHAR(20) NULL,
	LastName VARCHAR(20) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Phone VARCHAR(24) NOT NULL,
	[Address] VARCHAR(50) NOT NULL,
	PRIMARY KEY (ClientID)
)

CREATE TABLE Counsellors
(
	CounsellorID INT IDENTITY (1, 1) NOT NULL,
	[Name] VARCHAR(40) NOT NULL
	PRIMARY KEY (CounsellorID)
)

CREATE TABLE Appointments
(
	AppointmentID INT IDENTITY (1, 1),
	AppointmentDate DATETIME NOT NULL,
	ClientID INT NOT NULL,
	CounsellorID INT NOT NULL,
	Notes NTEXT NULL
	PRIMARY KEY (AppointmentID)
	FOREIGN KEY (ClientID) REFERENCES Clients(ClientID),
	FOREIGN KEY (CounsellorID) REFERENCES Counsellors(CounsellorID)
)

CREATE TABLE Logins
(
	Username VARCHAR(40) NOT NULL,
	[Password] VARCHAR(60) NOT NULL,
	StaffType VARCHAR(40) NOT NULL,
	PRIMARY KEY (Username)
)
GO
