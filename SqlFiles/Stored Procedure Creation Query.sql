--***DROP PROCEDURES***
IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'CreateCounsellor'
)
DROP PROCEDURE CreateCounsellor

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'UpdateCounsellor'
)
DROP PROCEDURE UpdateCounsellor

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'DeleteCounsellor'
)
DROP PROCEDURE DeleteCounsellor

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'CreateClient'
)
DROP PROCEDURE CreateClient

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'UpdateClient'
)
DROP PROCEDURE UpdateClient

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'DeleteClient'
)
DROP PROCEDURE DeleteClient

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'CreateAppointment'
)
DROP PROCEDURE CreateAppointment

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'UpdateAppointment'
)
DROP PROCEDURE UpdateAppointment

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'DeleteAppointment'
)
DROP PROCEDURE DeleteAppointment

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'CreateLogin'
)
DROP PROCEDURE CreateLogin

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'UpdateLogin'
)
DROP PROCEDURE UpdateLogin

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'DeleteLogin'
)
DROP PROCEDURE DeleteLogin

IF EXISTS(
	SELECT * FROM sys.objects
	WHERE NAME = 'GetClient'
)
DROP PROCEDURE GetClient
GO
--***END DROP PROCEDURES***

--CREATE PROCEDURES
CREATE PROCEDURE CreateCounsellor
@Name VARCHAR(40) = NULL
AS
	DECLARE @ReturnCode AS INT
	SET @ReturnCode = 1

	IF @Name IS NULL
		RAISERROR('AddCounsellor - Name is null', 16, 1)

	INSERT INTO Counsellors ([Name])
	VALUES (@Name)
	
	IF @@ERROR = 0
		SET @ReturnCode = 0

	RETURN @ReturnCode
GO

CREATE PROCEDURE UpdateCounsellor
@CounsellorID INT = NULL,
@Name VARCHAR(40) = NULL
AS
	DECLARE @ReturnCode AS INT
	SET @ReturnCode = 1

	IF @CounsellorID IS NULL
		RAISERROR('UpdateCounsellor - CounsellorID is null', 16, 1)

	UPDATE Counsellors
	SET [Name] = CASE WHEN (@Name IS NULL) THEN [Name] ELSE @Name END
	WHERE CounsellorID = @CounsellorID

	IF @@ERROR = 0
		SET @ReturnCode = 0

	RETURN @ReturnCode
GO

CREATE PROCEDURE DeleteCounsellor
@CounsellorID INT = NULL
AS
	DECLARE @ReturnCode AS INT
	SET @ReturnCode = 1

	IF @CounsellorID IS NULL
		RAISERROR('DeleteCounsellor - CounsellorID is null', 16, 1)

	DELETE FROM Counsellors
	WHERE CounsellorID = @CounsellorID

	IF @@ERROR = 0
		SET @ReturnCode = 0

	RETURN @ReturnCode
GO

CREATE PROCEDURE CreateClient
@FirstName VARCHAR(10) = NULL,
@MiddleName VARCHAR(10) = NULL,
@LastName VARCHAR(20) = NULL,
@Email VARCHAR(50) = NULL,
@Phone VARCHAR(24) = NULL,
@Address VARCHAR(50) = NULL
AS
	DECLARE @ReturnCode AS INT
	SET @ReturnCode = 1

	IF @LastName IS NULL
		RAISERROR('AddClient - LastName is null', 16, 1)

	IF @FirstName IS NULL
		RAISERROR('AddClient - FirstName is null', 16, 1)

	IF @Email IS NULL
		RAISERROR('AddClient - Email is null', 16, 1)

	IF @Phone IS NULL
		RAISERROR('AddClient - Phone is null', 16, 1)

	IF @Address IS NULL
		RAISERROR('AddClient - Address is null', 16, 1)

	INSERT INTO Clients
	VALUES (@FirstName, @MiddleName, @LastName, @Email, @Phone, @Address)
	
	IF @@ERROR = 0
		SET @ReturnCode = 0

	RETURN @ReturnCode
GO

CREATE PROCEDURE UpdateClient
@ClientID INT = NULL,
@FirstName VARCHAR(10) = NULL,
@MiddleName VARCHAR(10) = NULL,
@LastName VARCHAR(20) = NULL,
@Email VARCHAR(50) = NULL,
@Phone VARCHAR(24) = NULL,
@Address VARCHAR(50) = NULL
AS
	DECLARE @ReturnCode AS INT
	SET @ReturnCode = 1

	IF @ClientID IS NULL
		RAISERROR('UpdateClient - ClientID is null', 16, 1)

	UPDATE Clients
	SET FirstName = CASE WHEN (@FirstName IS NULL) THEN FirstName ELSE @FirstName END,
	MiddleName = CASE WHEN (@MiddleName IS NULL) THEN MiddleName ELSE @MiddleName END,
	LastName = CASE WHEN (@LastName IS NULL) THEN LastName ELSE @LastName END,
	Email = CASE WHEN (@Email IS NULL) THEN Email ELSE @Email END,
	Phone = CASE WHEN (@Phone IS NULL) THEN Phone ELSE @Phone END,
	[Address] = CASE WHEN (@Address IS NULL) THEN Address ELSE @Address END
	WHERE ClientID = @ClientID

	IF @@ERROR = 0
		SET @ReturnCode = 0

	RETURN @ReturnCode
GO

CREATE PROCEDURE DeleteClient
@ClientID INT = NULL
AS
	DECLARE @ReturnCode AS INT
	SET @ReturnCode = 1

	IF @ClientID IS NULL
		RAISERROR('DeleteClient - ClientID is null', 16, 1)

	DELETE FROM Clients
	WHERE ClientID = @ClientID

	IF @@ERROR = 0
		SET @ReturnCode = 0

	RETURN @ReturnCode
GO

CREATE PROCEDURE GetClient
@FirstName VARCHAR(10) = NULL,
@LastName VARCHAR(20) = NULL
AS
	DECLARE @ClientID INT
	select *
	from Clients
	where FirstName = @FirstName and LastName = @LastName

	--RETURN @ClientID
GO

CREATE PROCEDURE CreateAppointment
@AppointmentDate DATETIME = NULL,
@ClientID INT = NULL,
@CounsellorID INT = NULL,
@Notes NTEXT = NULL
AS
DECLARE @ReturnCode AS INT
	SET @ReturnCode = 1

	IF @AppointmentDate IS NULL
		RAISERROR('BookAppointment - AppointmentDate is null', 16, 1)

	IF @ClientID IS NULL
		RAISERROR('BookAppointment - ClientID is null', 16, 1)

	IF @CounsellorID IS NULL
		RAISERROR('BookAppointment - CounsellorID is null', 16, 1)

	INSERT INTO Appointments
	VALUES (@AppointmentDate, @ClientID, @CounsellorID, @Notes)
	
	IF @@ERROR = 0
		SET @ReturnCode = 0

	RETURN @ReturnCode
GO

CREATE PROCEDURE UpdateAppointment
@AppointmentID INT = NULL,
@AppointmentDate DATETIME = NULL,
@ClientID INT = NULL,
@CounsellorID INT = NULL,
@Notes NTEXT = NULL
AS
	DECLARE @ReturnCode AS INT
	SET @ReturnCode = 1

	IF @AppointmentID IS NULL
		RAISERROR('UpdateAppointment - AppointmentID is null', 16, 1)

	UPDATE Appointments
	SET AppointmentDate = CASE WHEN (@AppointmentDate IS NULL) THEN AppointmentDate ELSE @AppointmentDate END,
	ClientID = CASE WHEN (@ClientID IS NULL) THEN ClientID ELSE @ClientID END,
	CounsellorID = CASE WHEN (@CounsellorID IS NULL) THEN CounsellorID ELSE @CounsellorID END,
	Notes = CASE WHEN (@Notes IS NULL) THEN Notes ELSE @Notes END
	WHERE AppointmentID = @AppointmentID

	IF @@ERROR = 0
		SET @ReturnCode = 0

	RETURN @ReturnCode
GO

CREATE PROCEDURE DeleteAppointment
@AppointmentID INT = NULL
AS
	DECLARE @ReturnCode AS INT
	SET @ReturnCode = 1

	IF @AppointmentID IS NULL
		RAISERROR('DeleteAppointment - AppointmentID is null', 16, 1)

	DELETE FROM Appointments
	WHERE AppointmentID = @AppointmentID

	IF @@ERROR = 0
		SET @ReturnCode = 0

	RETURN @ReturnCode
GO

CREATE PROCEDURE GetAppointments
@ClientID INT = NULL
AS
	SELECT * FROM Appointments	
GO

CREATE PROCEDURE GetAppointmentsForClient
@ClientID INT = NULL
AS
	IF @ClientID IS NULL
		RAISERROR('GetAppointmentsForClient - ClientID is null', 16, 1)
	SELECT * FROM Appointments WHERE ClientID = @ClientID
GO


CREATE PROCEDURE CreateLogin
@Username VARCHAR(40) = NULL,
@Password VARCHAR(60) = NULL,
@StaffType VARCHAR(40) = NULL
AS
	DECLARE @ReturnCode AS INT
	SET @ReturnCode = 1

	IF @Username IS NULL
		RAISERROR('AddClient - LastName is null', 16, 1)

	IF @Password IS NULL
		RAISERROR('AddClient - FirstName is null', 16, 1)

	IF @StaffType IS NULL
		RAISERROR('AddClient - Email is null', 16, 1)

	INSERT INTO Logins (Username, [Password], StaffType)
	VALUES (@Username, @Password, @StaffType)
	
	IF @@ERROR = 0
		SET @ReturnCode = 0

	RETURN @ReturnCode
GO

CREATE PROCEDURE UpdateLogin
@Username VARCHAR(40) = NULL,
@Password VARCHAR(60) = NULL,
@StaffType VARCHAR(40) = NULL
AS
	DECLARE @ReturnCode AS INT
	SET @ReturnCode = 1

	IF @Username IS NULL
		RAISERROR('UpdateLogin - @Username is null', 16, 1)

	UPDATE Logins
	SET [Password] = CASE WHEN (@Password IS NULL) THEN Password ELSE @Password END,
	StaffType = CASE WHEN (@StaffType IS NULL) THEN StaffType ELSE @StaffType END
	WHERE Username = @Username

	IF @@ERROR = 0
		SET @ReturnCode = 0

	RETURN @ReturnCode
GO

CREATE PROCEDURE DeleteLogin
@Username VARCHAR(40) = NULL
AS
	DECLARE @ReturnCode AS INT
	SET @ReturnCode = 1

	IF @Username IS NULL
		RAISERROR('DeleteLogin - Username is null', 16, 1)

	DELETE FROM Logins
	WHERE Username = @Username
	
	IF @@ERROR = 0
		SET @ReturnCode = 0

	RETURN @ReturnCode
GO
